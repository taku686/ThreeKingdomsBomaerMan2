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
        public class PlayerNormalSkillState : State
        {
            private PhotonNetworkManager PhotonNetworkManager => Owner.photonNetworkManager;
            private PhotonView PhotonView => Owner.photonView;

            protected override void OnEnter(State prevState)
            {
                var index = PhotonView.OwnerActorNr;
                var weaponData = PhotonNetworkManager.GetWeaponData(index);
                var skillData = weaponData.NormalSkillMasterData;
                ActivateSkill(skillData.SkillEffectType);
                PhotonNetwork.LocalPlayer.SetSkillData(skillData.Id);
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                Owner.animator.SetTrigger(hashKey);
                Owner.observableStateMachineTrigger.OnStateExitAsObservable().Where(info =>
                    info.StateInfo.IsName(key)).Take(1).Subscribe(onStateInfo =>
                {
                    Owner.stateMachine.Dispatch((int)PLayerState.Idle);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void ActivateSkill(SkillEffectType effectType)
            {
                switch (effectType)
                {
                    case SkillEffectType.Heal:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
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
                        break;
                    case SkillEffectType.HpBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.AttackBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.SpeedBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.BombLimitBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.FireRangeBuff:
                        PlayBackAnimation(GameCommonData.BuffHashKey, GameCommonData.BuffKey);
                        break;
                    case SkillEffectType.Jump:
                        PlayBackAnimation(GameCommonData.JumpHashKey, GameCommonData.JumpKey);
                        break;
                    case SkillEffectType.Dash:
                        break;
                    case SkillEffectType.AllStatusDebuff:
                        PlayBackAnimation(GameCommonData.NormalHashKey, GameCommonData.NormalKey);
                        break;
                }
            }
        }
    }
}