using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Skill;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Bomb
{
    public class AttributeBomb : BombBase
    {
        [SerializeField] private BombExplosionRepository _bombExplosionRepository;
        [SerializeField] private AttributeBombEffectRepository _attributeBombEffectRepository;
        private GameObject _attributeEffectObj;
        private AbnormalCondition _abnormalCondition;
        private bool _isHitAttack;

        public override void Setup
        (
            int damageAmount,
            int fireRange,
            int instantiationId,
            int explosionTime,
            int skillId,
            AbnormalCondition abnormalCondition
        )
        {
            _abnormalCondition = abnormalCondition;
            base.Setup(damageAmount, fireRange, instantiationId, explosionTime, skillId, abnormalCondition);
            SetupAttributeEffect(abnormalCondition);
        }

        private void SetupAttributeEffect(AbnormalCondition abnormalCondition)
        {
            if (_attributeEffectObj != null)
            {
                Destroy(_attributeEffectObj);
            }

            var attributeEffect = _attributeBombEffectRepository.Get(abnormalCondition);
            _attributeEffectObj = Instantiate(attributeEffect, transform).gameObject;
            _attributeEffectObj.transform.localPosition = Vector3.zero;
            _attributeEffectObj.transform.localEulerAngles = Vector3.zero;
        }

        protected override async UniTask Explosion(int damageAmount)
        {
            SetupExplosion(_abnormalCondition, damageAmount);
            base.Explosion(damageAmount).Forget();
        }

        private void SetupExplosion
        (
            AbnormalCondition abnormalCondition,
            int damageAmount
        )
        {
            var bombExplosion = _bombExplosionRepository.Get(abnormalCondition);
            bombExplosion.SetDamage(damageAmount);
            var bombExplosionClone = Instantiate(bombExplosion, transform.position, transform.rotation).gameObject;
            var particles = bombExplosionClone.GetComponentsInChildren<ParticleSystem>();
            foreach (var particle in particles)
            {
                var main = particle.main;
                main.playOnAwake = true;
                main.stopAction = ParticleSystemStopAction.Destroy;
            }

            var explosionCollider = bombExplosionClone.GetComponent<SphereCollider>();
            explosionCollider
                .OnTriggerEnterAsObservable()
                .Select(hit => hit.gameObject)
                .Where(AttackSkillBase.IsObstaclesTag)
                .Subscribe(HitPlayer)
                .AddTo(gameObject);
        }

        private void HitPlayer(GameObject hitPlayer)
        {
            if (_skillId == GameCommonData.InvalidNumber)
            {
                return;
            }

            var hitPlayerPhotonView = hitPlayer.GetComponent<PhotonView>();
            if (hitPlayerPhotonView == null)
            {
                return;
            }

            if (_instantiationId == hitPlayerPhotonView.InstantiationId)
            {
                return;
            }

            if (_isHitAttack)
            {
                return;
            }

            _isHitAttack = true;
            var statusInfo = hitPlayer.GetComponent<PlayerConditionInfo>();
            var playerIndex = statusInfo.GetPlayerIndex();
            var dic = new Dictionary<int, int> { { playerIndex, _skillId } };
            PhotonNetwork.LocalPlayer.SetHitAttackData(dic);
        }
    }
}