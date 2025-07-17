using Character;
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
        private PutBomb _putBomb;

        public void Initialize
        (
            ActiveSkillManager activeSkillManager,
            PhotonNetworkManager photonNetworkManager,
            GameObject playerCore,
            PutBomb putBomb,
            int playerKey,
            PlayerStatusInfo playerStatusInfo
        )
        {
            _putBomb = putBomb;
            _activeSkillManager = activeSkillManager;
            _photonNetworkManager = photonNetworkManager;
            _playerTransform = playerCore.transform;
            _photonView = playerCore.GetComponent<PhotonView>();
            var instantiationId = _photonView.InstantiationId;
            Subscribe(instantiationId, playerKey, playerStatusInfo);
        }

        private void Subscribe
        (
            int instantiationId,
            int playerKey,
            PlayerStatusInfo playerStatusInfo
        )
        {
            _photonNetworkManager
                ._ActivateSkillObservable
                .Where(tuple => tuple.Item1 == instantiationId)
                .Subscribe(tuple =>
                {
                    var skillMasterData = tuple.Item2;
                    var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
                    var characterData = _photonNetworkManager.GetCharacterData(playerKey);
                    var characterId = characterData.Id;
                    var statusSkillMasterData = weaponData.StatusSkillMasterDatum;
                    _activeSkillManager.ActivateSkill(skillMasterData, _playerTransform, _putBomb);
                    _activeSkillManager.Heal(skillMasterData);
                    _activeSkillManager.BuffSkill(skillMasterData, statusSkillMasterData, characterId, playerStatusInfo);
                })
                .AddTo(gameObject);
        }
    }
}