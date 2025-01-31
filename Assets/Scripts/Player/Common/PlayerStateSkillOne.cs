using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager;
using Manager.NetworkManager;
using Photon.Pun;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerNormalSkillState : State
        {
            private PhotonNetworkManager PhotonNetworkManager => Owner._photonNetworkManager;
            private PhotonView PhotonView => Owner.photonView;
            private string HpKey => Owner._hpKey;
            private TranslateStatusForBattleUseCase TranslateStatusForBattleUseCase => Owner._translateStatusForBattleUseCase;
            private ApplyStatusSkillUseCase ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private Subject<(StatusType statusType, float value)> StatusBuff => Owner._statusBuffSubject;
            private Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> StatusBuffUi => Owner._statusBuffUiSubject;

            protected override void OnEnter(State prevState)
            {
                var index = PhotonView.OwnerActorNr;
                var weaponData = PhotonNetworkManager.GetWeaponData(index);
                var normalSkillData = weaponData.NormalSkillMasterData;
                var statusSkillData = weaponData.StatusSkillMasterData;
                var characterData = PhotonNetworkManager.GetCharacterData(index);
                var characterId = characterData.Id;
                ActivateSkill(normalSkillData, statusSkillData, characterId);
                PhotonNetwork.LocalPlayer.SetSkillData(normalSkillData.Id);
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                Owner._animator.SetTrigger(hashKey);
                Owner._observableStateMachineTrigger.OnStateExitAsObservable().Where(info =>
                    info.StateInfo.IsName(key)).Take(1).Subscribe(_ =>
                {
                    Owner._stateMachine.Dispatch((int)PLayerState.Idle);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void ActivateSkill
            (
                SkillMasterData normalSkill,
                SkillMasterData statusSkillData,
                int charaId
            )
            {
                var statusId = statusSkillData.Id;
                var hpType = StatusType.Hp;
                var attackType = StatusType.Attack;
                var speedType = StatusType.Speed;
                var bombLimitType = StatusType.BombLimit;
                var fireRangeType = StatusType.FireRange;
                switch (normalSkill.SkillEffectType)
                {
                    case SkillEffectType.Heal:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        var hpRate = TranslateStatusForBattleUseCase.Heal((int)normalSkill.Amount);
                        Debug.Log(hpRate);
                        SynchronizedValue.Instance.SetValue(HpKey, hpRate);
                        break;
                    case SkillEffectType.Kick:
                        PlayBackAnimation(GameCommonData.KickHashKey, GameCommonData.KickKey);
                        break;
                    case SkillEffectType.BombDestruction:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        break;
                    case SkillEffectType.BombDestructionShot:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        break;
                    case SkillEffectType.BombBlowOff:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        break;
                    case SkillEffectType.BombBlowOffShot:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        break;
                    case SkillEffectType.Barrier:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.SkillBarrier:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.AllStatusBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, hpType).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, attackType).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, speedType).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, bombLimitType).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, fireRangeType).Forget();
                        break;
                    case SkillEffectType.HpBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, hpType).Forget();
                        break;
                    case SkillEffectType.AttackBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, attackType).Forget();
                        break;
                    case SkillEffectType.SpeedBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, speedType).Forget();
                        break;
                    case SkillEffectType.BombLimitBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, bombLimitType).Forget();
                        break;
                    case SkillEffectType.FireRangeBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, fireRangeType).Forget();
                        break;
                    case SkillEffectType.Jump:
                        PlayBackAnimation(GameCommonData.JumpHashKey, GameCommonData.JumpKey);
                        break;
                    case SkillEffectType.Dash:
                        break;
                    case SkillEffectType.AllStatusDebuff:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, fireRangeType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, bombLimitType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, speedType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, attackType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, hpType, false, true).Forget();
                        break;
                }
            }

            private async UniTaskVoid ApplyBuffStatus
            (
                int characterId,
                SkillMasterData normalSkill,
                int statusSKillId,
                StatusType statusType,
                bool isBuff = true,
                bool isDebuff = false
            )
            {
                var value = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSKillId, statusType);
                var appliedSkillValue = ApplyStatusSkillUseCase.ApplyBuffStatusSkill(characterId, normalSkill.Id, statusType, value);
                var translatedValue = TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, appliedSkillValue);
                StatusBuff.OnNext((statusType, translatedValue));
                StatusBuffUi.OnNext((statusType, value: appliedSkillValue, isBuff, isDebuff));
                await UniTask.Delay((int)normalSkill.EffectTime * 1000);
                var translatedPrefValue = TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, value);
                StatusBuff.OnNext((statusType, translatedPrefValue));
                StatusBuffUi.OnNext((statusType, value, isBuff: false, isDebuff: false));
            }
        }
    }
}