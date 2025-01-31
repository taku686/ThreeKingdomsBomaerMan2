using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using UniRx;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSpecialSkillState : State
        {
            private PhotonNetworkManager PhotonNetworkManager => Owner._photonNetworkManager;
            private PhotonView PhotonView => Owner.photonView;
            private TranslateStatusForBattleUseCase TranslateStatusForBattleUseCase => Owner._translateStatusForBattleUseCase;
            private ApplyStatusSkillUseCase ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private Subject<(StatusType statusType, float value)> StatusBuff => Owner._statusBuffSubject;
            private Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> StatusBuffUi => Owner._statusBuffUiSubject;

            protected override void OnEnter(State prevState)
            {
                var index = PhotonView.OwnerActorNr;
                var weaponData = PhotonNetworkManager.GetWeaponData(index);
                var specialSkillData = weaponData.SpecialSkillMasterData;
                var statusSkillData = weaponData.StatusSkillMasterData;
                var characterData = PhotonNetworkManager.GetCharacterData(index);
                var characterId = characterData.Id;
                ActivateSkill(specialSkillData, statusSkillData, characterId);
                PhotonNetwork.LocalPlayer.SetSkillData(specialSkillData.Id);
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
                SkillMasterData specialSkill,
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
                switch (specialSkill.SkillEffectType)
                {
                    case SkillEffectType.Kick:
                        PlayBackAnimation(GameCommonData.KickHashKey, GameCommonData.KickKey);
                        break;
                    case SkillEffectType.GodPower:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        ApplyBuffStatus(charaId, specialSkill, statusId, hpType).Forget();
                        ApplyBuffStatus(charaId, specialSkill, statusId, attackType).Forget();
                        ApplyBuffStatus(charaId, specialSkill, statusId, speedType).Forget();
                        ApplyBuffStatus(charaId, specialSkill, statusId, bombLimitType).Forget();
                        ApplyBuffStatus(charaId, specialSkill, statusId, fireRangeType).Forget();
                        break;
                    default:
                        PlayBackAnimation(GameCommonData.SpecialHashKey, GameCommonData.SpecialKey);
                        break;
                }
            }

            private async UniTaskVoid ApplyBuffStatus
            (
                int characterId,
                SkillMasterData specialSkill,
                int statusSKillId,
                StatusType statusType,
                bool isBuff = true,
                bool isDebuff = false
            )
            {
                var value = ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSKillId, statusType);
                var appliedSkillValue = ApplyStatusSkillUseCase.ApplyBuffStatusSkill(characterId, specialSkill.Id, statusType, value);
                var translatedValue = TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, appliedSkillValue);
                StatusBuff.OnNext((statusType, translatedValue));
                StatusBuffUi.OnNext((statusType, value: appliedSkillValue, isBuff, isDebuff));
                await UniTask.Delay((int)specialSkill.EffectTime * 1000);
                var translatedPrefValue = TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, value);
                StatusBuff.OnNext((statusType, translatedPrefValue));
                StatusBuffUi.OnNext((statusType, value, isBuff: false, isDebuff: false));
            }
        }
    }
}