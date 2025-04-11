using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager;
using Manager.NetworkManager;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerNormalSkillState : State
        {
            private Animator _Animator => Owner._animator;
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private PhotonView _PhotonView => Owner.photonView;
            private string _HpKey => Owner._hpKey;
            private TranslateStatusForBattleUseCase _TranslateStatusForBattleUseCase => Owner._translateStatusForBattleUseCase;
            private ApplyStatusSkillUseCase _ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private Subject<(StatusType statusType, float value)> _StatusBuff => Owner._statusBuffSubject;
            private Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> _StatusBuffUi => Owner._statusBuffUiSubject;

            protected override void OnEnter(State prevState)
            {
                var index = _PhotonView.OwnerActorNr;
                var weaponData = _PhotonNetworkManager.GetWeaponData(index);
                var normalSkillData = weaponData.NormalSkillMasterData;
                var statusSkillData = weaponData.StatusSkillMasterData;
                var characterData = _PhotonNetworkManager.GetCharacterData(index);
                var characterId = characterData.Id;
                ActivateSkill(normalSkillData, statusSkillData, characterId);
                PhotonNetwork.LocalPlayer.SetSkillData(normalSkillData.Id);
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                _Animator.SetTrigger(hashKey);
                _ObservableStateMachineTrigger
                    .OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(key))
                    .Take(1)
                    .Subscribe(_ => { Owner._stateMachine.Dispatch((int)PLayerState.Idle); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void ActivateSkill
            (
                SkillMasterData normalSkill,
                SkillMasterData statusSkillData,
                int charaId
            )
            {
                var statusId = statusSkillData.Id;
                const StatusType hpType = StatusType.Hp;
                const StatusType attackType = StatusType.Attack;
                const StatusType speedType = StatusType.Speed;
                const StatusType bombLimitType = StatusType.BombLimit;
                const StatusType fireRangeType = StatusType.FireRange;
                switch (normalSkill.SkillEffectType)
                {
                    case SkillEffectType.Heal:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        var hpRate = _TranslateStatusForBattleUseCase.Heal((int)normalSkill.Amount);
                        SynchronizedValue.Instance.SetValue(_HpKey, hpRate);
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
                    case SkillEffectType.AllStatusDebuff:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        ApplyBuffStatus(charaId, normalSkill, statusId, fireRangeType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, bombLimitType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, speedType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, attackType, false, true).Forget();
                        ApplyBuffStatus(charaId, normalSkill, statusId, hpType, false, true).Forget();
                        break;
                    case SkillEffectType.Hp:
                        break;
                    case SkillEffectType.Attack:
                        break;
                    case SkillEffectType.Speed:
                        break;
                    case SkillEffectType.BombLimit:
                        break;
                    case SkillEffectType.FireRange:
                        break;
                    case SkillEffectType.ContinuousHeal:
                        break;
                    case SkillEffectType.PerfectBarrier:
                        break;
                    case SkillEffectType.Reborn:
                        break;
                    case SkillEffectType.SlowTime:
                        break;
                    case SkillEffectType.ProhibitedSkill:
                        break;
                    case SkillEffectType.Paralysis:
                        break;
                    case SkillEffectType.Confusion:
                        break;
                    case SkillEffectType.Illusion:
                        break;
                    case SkillEffectType.WallThrough:
                        break;
                    case SkillEffectType.WallDestruction:
                        break;
                    case SkillEffectType.Teleport:
                        break;
                    case SkillEffectType.Transparent:
                        break;
                    case SkillEffectType.Clairvoyance:
                        break;
                    case SkillEffectType.LinerArrangement:
                        break;
                    case SkillEffectType.CircleArrangement:
                        break;
                    case SkillEffectType.ArrowArrangement:
                        break;
                    case SkillEffectType.Meteor:
                        break;
                    case SkillEffectType.EnemyBlowOff:
                        break;
                    case SkillEffectType.BlastReflection:
                        break;
                    case SkillEffectType.Frozen:
                        break;
                    case SkillEffectType.RewardCoin:
                        break;
                    case SkillEffectType.RewardGem:
                        break;
                    case SkillEffectType.PenetrationBomb:
                        break;
                    case SkillEffectType.DiffusionBomb:
                        break;
                    case SkillEffectType.FullPowerBomb:
                        break;
                    case SkillEffectType.ParalysisBomb:
                        break;
                    case SkillEffectType.ConfusionBomb:
                        break;
                    case SkillEffectType.PoisonBomb:
                        break;
                    case SkillEffectType.IceBomb:
                        break;
                    case SkillEffectType.GoldenBomb:
                        break;
                    case SkillEffectType.ChaseBomb:
                        break;
                    case SkillEffectType.RotateBomb:
                        break;
                    case SkillEffectType.GenerateWall:
                        break;
                    case SkillEffectType.CantMoveTrap:
                        break;
                    case SkillEffectType.PoisonTrap:
                        break;
                    case SkillEffectType.GenerateBombAlly:
                        break;
                    case SkillEffectType.EnemyBlowOffShot:
                        break;
                    case SkillEffectType.HpDebuff:
                        break;
                    case SkillEffectType.AttackDebuff:
                        break;
                    case SkillEffectType.SpeedDebuff:
                        break;
                    case SkillEffectType.BombLimitDebuff:
                        break;
                    case SkillEffectType.FireRangeDebuff:
                        break;
                    case SkillEffectType.PoisonShot:
                        break;
                    case SkillEffectType.IceShot:
                        break;
                    case SkillEffectType.ParalysisShot:
                        break;
                    case SkillEffectType.ConfusionShot:
                        break;
                    case SkillEffectType.Poison:
                        break;
                    case SkillEffectType.RandomDebuff:
                        break;
                    case SkillEffectType.FastMove:
                        break;
                    case SkillEffectType.BombThrough:
                        break;
                    case SkillEffectType.BlackHole:
                        break;
                    case SkillEffectType.Summon:
                        break;
                    case SkillEffectType.Fear:
                        break;
                    case SkillEffectType.GodPower:
                        break;
                    case SkillEffectType.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
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
                var value = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSKillId, statusType);
                var appliedSkillValue = _ApplyStatusSkillUseCase.ApplyBuffStatusSkill(characterId, normalSkill.Id, statusType, value);
                var translatedValue = _TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, appliedSkillValue);
                _StatusBuff.OnNext((statusType, translatedValue));
                _StatusBuffUi.OnNext((statusType, value: appliedSkillValue, isBuff, isDebuff));
                await UniTask.Delay((int)normalSkill.EffectTime * 1000);
                var translatedPrefValue = _TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, value);
                _StatusBuff.OnNext((statusType, translatedPrefValue));
                _StatusBuffUi.OnNext((statusType, value, isBuff: false, isDebuff: false));
            }
        }
    }
}