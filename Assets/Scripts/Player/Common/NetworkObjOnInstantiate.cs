using System;
using Common.Data;
using Photon.Pun;
using Repository;
using UnityEngine;
using UnityEngine.SceneManagement;
using UseCase.Battle;
using Zenject;

namespace Player.Common
{
    public class NetworkObjOnInstantiate : MonoBehaviour, IPunInstantiateMagicCallback
    {
        [Inject] private SetupAnimatorUseCase _setupAnimatorUseCase;
        [Inject] private CharacterCreateUseCase _characterCreateUseCase;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;

        private const int WeaponInstantiationDataLength = 3;

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var instantiationData = info.photonView.InstantiationData;
            if (instantiationData == null || instantiationData.Length == 0)
            {
                Debug.LogError("Instantiation data is null or empty.");
                return;
            }

            var parentInstantiationId = (int)instantiationData[0];
            var weaponId = (int)instantiationData[1];
            var parentTransform = FindParent(parentInstantiationId);
            if (parentTransform == null)
            {
                Debug.LogError($"Parent with InstantiationId {parentInstantiationId} not found.");
                return;
            }

            if (gameObject.CompareTag(GameCommonData.PlayerTag))
            {
                SetupPlayerObjTransform(parentTransform, weaponId);
            }

            if (gameObject.CompareTag(GameCommonData.WeaponTag))
            {
                if (instantiationData.Length >= WeaponInstantiationDataLength)
                {
                    var isLeftHand = (bool)instantiationData[2];
                    SetupWeaponObjTransform(parentTransform, weaponId, isLeftHand);
                }
            }
        }

        private static Transform FindParent(int instantiationId)
        {
            var players = GameObject.FindGameObjectsWithTag(GameCommonData.PlayerTag);
            foreach (var player in players)
            {
                var photonView = player.GetComponent<PhotonView>();
                if (photonView == null)
                {
                    continue;
                }

                if (photonView.InstantiationId == instantiationId)
                {
                    return player.transform;
                }
            }

            return null;
        }

        private void SetupPlayerObjTransform(Transform parent, int weaponId)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            var animator = gameObject.GetComponent<Animator>();
            var weaponData = _weaponMasterDataRepository.GetWeaponData(weaponId);
            _setupAnimatorUseCase.SetAnimatorController(gameObject, weaponData.WeaponType, animator);
        }

        private void SetupWeaponObjTransform(Transform parent, int weaponId, bool isLeftHand)
        {
            var weaponData = _weaponMasterDataRepository.GetWeaponData(weaponId);
            _characterCreateUseCase.FixWeaponTransform(parent.gameObject, gameObject, weaponData, isLeftHand);
        }
    }
}