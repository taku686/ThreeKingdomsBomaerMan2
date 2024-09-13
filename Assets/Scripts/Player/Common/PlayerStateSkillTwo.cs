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
            private PhotonNetworkManager PhotonNetworkManager => Owner.photonNetworkManager;
            private PhotonView PhotonView => Owner.photonView;

            protected override void OnEnter(State prevState)
            {
                var index = PhotonView.OwnerActorNr;
                var weaponData = PhotonNetworkManager.GetWeaponData(index);
                var skillData = weaponData.SpecialSkillMasterData;
                ActivateSkill(skillData.SkillEffectType);
                PhotonNetwork.LocalPlayer.SetSkillData(skillData.Id);
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                Owner.animator.SetTrigger(hashKey);
                Owner.observableStateMachineTrigger.OnStateExitAsObservable().Where(info =>
                    info.StateInfo.IsName(key)).Take(1).Subscribe(_ =>
                {
                    Owner.stateMachine.Dispatch((int)PLayerState.Idle);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private void ActivateSkill(SkillEffectType effectType)
            {
                switch (effectType)
                {
                    case SkillEffectType.Kick:
                        PlayBackAnimation(GameCommonData.KickHashKey, GameCommonData.KickKey);
                        break;
                    default:
                        PlayBackAnimation(GameCommonData.SpecialHashKey, GameCommonData.SpecialKey);
                        break;
                }
            }
        }
    }
}