using Common.Data;
using Manager.NetworkManager;
using Photon.Pun;
using Skill;
using UniRx;
using UnityEngine;

namespace Player.Common
{
    public class PlayerSkill : MonoBehaviour
    {
        private PhotonView _photonView;
        private ActiveSkillManager _activeSkillManager;
        private PhotonNetworkManager _photonNetworkManager;
        private Transform _playerTransform;

        public void Initialize
        (
            ActiveSkillManager activeSkillManager,
            PhotonNetworkManager photonNetworkManager,
            GameObject playerCore
        )
        {
            _activeSkillManager = activeSkillManager;
            _photonNetworkManager = photonNetworkManager;
            _playerTransform = playerCore.transform;
            _photonView = playerCore.GetComponent<PhotonView>();
            Subscribe(_photonView.InstantiationId);
        }

        private void Subscribe(int instantiationId)
        {
            _photonNetworkManager
                ._ActivateSkillObservable
                .Where(tuple => tuple.Item1 == instantiationId)
                .Subscribe(tuple =>
                {
                    var skillMasterData = tuple.Item2;
                    _activeSkillManager.ActivateSkill(skillMasterData, _playerTransform);
                    _activeSkillManager.Heal(skillMasterData);
                    _activeSkillManager.BuffSkill(skillMasterData);
                })
                .AddTo(gameObject);
        }
    }
}