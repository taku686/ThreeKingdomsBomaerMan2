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
            private PhotonNetworkManager _PhotonNetworkManager => Owner._photonNetworkManager;
            private PhotonView _PhotonView => Owner.photonView;
            private TranslateStatusForBattleUseCase _TranslateStatusForBattleUseCase => Owner._translateStatusForBattleUseCase;
            private ApplyStatusSkillUseCase _ApplyStatusSkillUseCase => Owner._applyStatusSkillUseCase;
            private Subject<(StatusType statusType, float value)> _StatusBuff => Owner._statusBuffSubject;
            private Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> _StatusBuffUi => Owner._statusBuffUiSubject;

            protected override void OnEnter(State prevState)
            {
                var index = _PhotonView.OwnerActorNr;
                var weaponData = _PhotonNetworkManager.GetWeaponData(index);
                var specialSkillData = weaponData.SpecialSkillMasterData;
                var statusSkillData = weaponData.StatusSkillMasterDatum;
                var characterData = _PhotonNetworkManager.GetCharacterData(index);
                var characterId = characterData.Id;
                ActivateSkill(specialSkillData, statusSkillData, characterId);
                PhotonNetwork.LocalPlayer.SetSkillData(specialSkillData.Id);
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                Owner._animator.SetTrigger(hashKey);
                Owner._observableStateMachineTrigger
                    .OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(key))
                    .Take(1)
                    .Subscribe(_ => { Owner._stateMachine.Dispatch((int)PLayerState.Idle); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void ActivateSkill
            (
                SkillMasterData specialSkill,
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
                    case SkillEffectType.Hp:
                    case SkillEffectType.Attack:
                    case SkillEffectType.Speed:
                    case SkillEffectType.BombLimit:
                    case SkillEffectType.FireRange:
                    case SkillEffectType.Heal:
                    case SkillEffectType.ContinuousHeal:
                    case SkillEffectType.Barrier:
                    case SkillEffectType.PerfectBarrier:
                    case SkillEffectType.Reborn:
                    case SkillEffectType.SlowTime:
                    case SkillEffectType.ProhibitedSkill:
                    case SkillEffectType.Paralysis:
                    case SkillEffectType.Confusion:
                    case SkillEffectType.Illusion:
                    case SkillEffectType.Jump:
                    case SkillEffectType.Dash:
                    case SkillEffectType.WallThrough:
                    case SkillEffectType.WallDestruction:
                    case SkillEffectType.Teleport:
                    case SkillEffectType.Transparent:
                    case SkillEffectType.Clairvoyance:
                    case SkillEffectType.LinerArrangement:
                    case SkillEffectType.CircleArrangement:
                    case SkillEffectType.ArrowArrangement:
                    case SkillEffectType.Meteor:
                    case SkillEffectType.BombDestruction:
                    case SkillEffectType.BombBlowOff:
                    case SkillEffectType.EnemyBlowOff:
                    case SkillEffectType.BlastReflection:
                    case SkillEffectType.SkillBarrier:
                    case SkillEffectType.Frozen:
                    case SkillEffectType.RewardCoin:
                    case SkillEffectType.RewardGem:
                    case SkillEffectType.PenetrationBomb:
                    case SkillEffectType.DiffusionBomb:
                    case SkillEffectType.FullPowerBomb:
                    case SkillEffectType.ParalysisBomb:
                    case SkillEffectType.ConfusionBomb:
                    case SkillEffectType.PoisonBomb:
                    case SkillEffectType.IceBomb:
                    case SkillEffectType.GoldenBomb:
                    case SkillEffectType.ChaseBomb:
                    case SkillEffectType.RotateBomb:
                    case SkillEffectType.GenerateWall:
                    case SkillEffectType.CantMoveTrap:
                    case SkillEffectType.PoisonTrap:
                    case SkillEffectType.GenerateBombAlly:
                    case SkillEffectType.BombDestructionShot:
                    case SkillEffectType.BombBlowOffShot:
                    case SkillEffectType.EnemyBlowOffShot:
                    case SkillEffectType.AllStatusBuff:
                    case SkillEffectType.HpBuff:
                    case SkillEffectType.AttackBuff:
                    case SkillEffectType.SpeedBuff:
                    case SkillEffectType.BombLimitBuff:
                    case SkillEffectType.FireRangeBuff:
                    case SkillEffectType.AllStatusDebuff:
                    case SkillEffectType.HpDebuff:
                    case SkillEffectType.AttackDebuff:
                    case SkillEffectType.SpeedDebuff:
                    case SkillEffectType.BombLimitDebuff:
                    case SkillEffectType.FireRangeDebuff:
                    case SkillEffectType.PoisonShot:
                    case SkillEffectType.IceShot:
                    case SkillEffectType.ParalysisShot:
                    case SkillEffectType.ConfusionShot:
                    case SkillEffectType.Poison:
                    case SkillEffectType.RandomDebuff:
                    case SkillEffectType.FastMove:
                    case SkillEffectType.BombThrough:
                    case SkillEffectType.BlackHole:
                    case SkillEffectType.Summon:
                    case SkillEffectType.Fear:
                    case SkillEffectType.Resistance:
                    case SkillEffectType.Defense:
                    case SkillEffectType.ResistanceBuff:
                    case SkillEffectType.DefenseBuff:
                    case SkillEffectType.None:
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
                var value = _ApplyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSKillId, statusType);
                var appliedSkillValue = _ApplyStatusSkillUseCase.ApplyBuffStatusSkill(characterId, specialSkill.Id, statusType, value);
                var translatedValue = _TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, appliedSkillValue);
                _StatusBuff.OnNext((statusType, translatedValue));
                _StatusBuffUi.OnNext((statusType, value: appliedSkillValue, isBuff, isDebuff));
                await UniTask.Delay((int)specialSkill.EffectTime * 1000);
                var translatedPrefValue = _TranslateStatusForBattleUseCase.TranslateStatusValue(statusType, value);
                _StatusBuff.OnNext((statusType, translatedPrefValue));
                _StatusBuffUi.OnNext((statusType, value, isBuff: false, isDebuff: false));
            }
        }
    }
}