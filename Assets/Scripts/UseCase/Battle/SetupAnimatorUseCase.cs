using System;
using Common.Data;
using Photon.Pun;
using Skill;
using UnityEngine;
using Zenject;

namespace UseCase.Battle
{
    public class SetupAnimatorUseCase : IDisposable
    {
        private readonly AnimatorControllerRepository _animatorControllerRepository;
        private readonly ActiveSkillManager _activeSkillManager;


        [Inject]
        public SetupAnimatorUseCase
        (
            AnimatorControllerRepository animatorControllerRepository,
            ActiveSkillManager activeSkillManager
        )
        {
            _animatorControllerRepository = animatorControllerRepository;
            _activeSkillManager = activeSkillManager;
        }

        public void SetAnimatorController(GameObject player, WeaponType weaponType, Animator animator = null)
        {
            if (animator == null)
            {
                animator = player.GetComponentInChildren<Animator>();
            }

            _activeSkillManager.SetupAnimator(animator);

            var photonAnimatorView = player.GetComponentInChildren<PhotonAnimatorView>();
            animator.runtimeAnimatorController = _animatorControllerRepository.GetAnimatorController(weaponType);
            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.SpeedhParameterName,
                PhotonAnimatorView.ParameterType.Float,
                PhotonAnimatorView.SynchronizeType.Continuous
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.SpeedvParameterName,
                PhotonAnimatorView.ParameterType.Float,
                PhotonAnimatorView.SynchronizeType.Continuous
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.NormalParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.SpecialParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.KickParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.JumpParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.DashParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.BuffParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.DeadParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.SlashParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.ImpactParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.DashAttackParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.SlashSpinParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.MagicShotParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.HitParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );

            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.RainArrowParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );
            
            photonAnimatorView.SetParameterSynchronized
            (
                GameCommonData.ImpactRockParameterName,
                PhotonAnimatorView.ParameterType.Trigger,
                PhotonAnimatorView.SynchronizeType.Discrete
            );
        }

        public void Dispose()
        {
        }
    }
}