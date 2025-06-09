using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class SkillEffectActivateUseCase : MonoBehaviour
{
    #region BuffEffect

    [SerializeField] private ParticleSystem healEffect;
    [SerializeField] private ParticleSystem hpEffect;
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private ParticleSystem speedEffect;
    [SerializeField] private ParticleSystem bombLimitEffect;
    [SerializeField] private ParticleSystem fireRangeEffect;
    [SerializeField] private ParticleSystem allStatusBuffEffect;
    [SerializeField] private ParticleSystem allStatusBuffEffect2;
    [SerializeField] private ParticleSystem allStatusBuffEffect3;
    [SerializeField] private ParticleSystem allStatusBuffEffect4;
    [SerializeField] private ParticleSystem barrierEffect;
    [SerializeField] private ParticleSystem skillBarrierEffect;
    [SerializeField] private ParticleSystem perfectBarrierEffect;
    [SerializeField] private ParticleSystem blastReflectionEffect;
    [SerializeField] private ParticleSystem debuffEffect;
    [SerializeField] private ParticleSystem prohibitedSkillEffect;
    [SerializeField] private ParticleSystem slowTimeEffect;

    #endregion

    #region AbnormalConditionEffect

    [Header("Abnormal Condition")] [SerializeField]
    private ParticleSystem paralysisEffect;

    [SerializeField] private ParticleSystem poisonEffect;
    [SerializeField] private ParticleSystem frozenEffect;
    [SerializeField] private ParticleSystem confusionEffect;
    [SerializeField] private ParticleSystem _charmEffect;
    [SerializeField] private ParticleSystem _miasmaEffect;
    [SerializeField] private ParticleSystem _darknessEffect;
    [SerializeField] private ParticleSystem _sealedEffect;
    [SerializeField] private ParticleSystem _lifeStealEffect;
    [SerializeField] private ParticleSystem _curseEffect;
    [SerializeField] private ParticleSystem _hellFireEffect;
    [SerializeField] private ParticleSystem fearEffect;
    [SerializeField] private ParticleSystem _timeStopEffect;
    [SerializeField] private ParticleSystem _apraxiaEffect;
    [SerializeField] private ParticleSystem _soakingWetEffect;
    [SerializeField] private ParticleSystem _burningEffect;

    #endregion

    private const float OneSecond = 1f;

    public void Initialize
    (
        IObservable<(int, SkillMasterData)> onSkillActivate,
        int actorNumber
    )
    {
        Subscribe(onSkillActivate, actorNumber);
        ForceAllEffectStop();
    }

    private void Subscribe
    (
        IObservable<(int, SkillMasterData)> onSkillActivate,
        int actorNumber
    )
    {
        onSkillActivate
            .Where(tuple => tuple.Item1 == actorNumber)
            .Select(tuple => tuple.Item2)
            .Subscribe(skillData =>
            {
                ActivateBuffEffect(skillData);
                ActivateAbnormalStateEffect(skillData);
            })
            .AddTo(gameObject.GetCancellationTokenOnDestroy());
    }


    private void ActivateBuffEffect(SkillMasterData skillMasterData)
    {
        switch (skillMasterData._SkillActionTypeEnum)
        {
            case SkillActionType.Heal:
                PlayEffect(healEffect, OneSecond).Forget();
                break;
            case SkillActionType.ContinuousHeal:
                PlayEffect(healEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.HpBuff:
                PlayEffect(hpEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.AttackBuff:
                PlayEffect(attackEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.SpeedBuff:
                PlayEffect(speedEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.BombLimitBuff:
                PlayEffect(bombLimitEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.FireRangeBuff:
                PlayEffect(fireRangeEffect, skillMasterData.EffectTime).Forget();
                break;
            //真なる力
            case SkillActionType.AllBuff when skillMasterData.Id == 37:
                PlayEffect(allStatusBuffEffect, skillMasterData.EffectTime).Forget();
                break;
            //神聖開放
            case SkillActionType.AllBuff when skillMasterData.Id == 88:
                PlayEffect(allStatusBuffEffect2, skillMasterData.EffectTime).Forget();
                break;
            //神々の御印
            case SkillActionType.AllBuff when skillMasterData.Id == 160:
                PlayEffect(allStatusBuffEffect3, skillMasterData.EffectTime).Forget();
                break;
            //守護者の覚醒
            case SkillActionType.AllBuff when skillMasterData.Id == 159:
                PlayEffect(allStatusBuffEffect4, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.Barrier:
                PlayEffect(barrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.SkillBarrier:
                PlayEffect(skillBarrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.PerfectBarrier:
                PlayEffect(perfectBarrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.BlastReflection:
                PlayEffect(blastReflectionEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.HpDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.AttackDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.SpeedDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.BombLimitDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.FireRangeDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.RandomDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.ProhibitedSkill:
                PlayEffect(prohibitedSkillEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillActionType.SlowTime:
                PlayEffect(slowTimeEffect, skillMasterData.EffectTime).Forget();
                break;
        }
    }

    private void ActivateBuffEffectInActive(SkillMasterData skillMasterData, bool isActive)
    {
        switch (skillMasterData._SkillActionTypeEnum)
        {
            //傲慢の呪い
            case SkillActionType.AllBuff when skillMasterData.Id == 167:
                PlayEffectInActive(allStatusBuffEffect4, isActive);
                break;
        }
    }

    private void ActivateAbnormalStateEffect(SkillMasterData skillMasterData)
    {
        var abnormalConditions = skillMasterData.AbnormalConditionEnum;
        foreach (var abnormalCondition in abnormalConditions)
        {
            switch (abnormalCondition)
            {
                case AbnormalCondition.Poison:
                    PlayEffect(poisonEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Paralysis:
                    PlayEffect(paralysisEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Confusion:
                    PlayEffect(confusionEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Frozen:
                    PlayEffect(frozenEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Fear:
                    PlayEffect(fearEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Charm:
                    PlayEffect(_charmEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Miasma:
                    PlayEffect(_miasmaEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Darkness:
                    PlayEffect(_darknessEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Sealed:
                    PlayEffect(_sealedEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.LifeSteal:
                    PlayEffect(_lifeStealEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Curse:
                    PlayEffect(_curseEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.HellFire:
                    PlayEffect(_hellFireEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.TimeStop:
                    PlayEffect(_timeStopEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Apraxia:
                    PlayEffect(_apraxiaEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.SoakingWet:
                    PlayEffect(_soakingWetEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.Burning:
                    PlayEffect(_burningEffect, skillMasterData.EffectTime).Forget();
                    break;
                case AbnormalCondition.All:
                    break;
                case AbnormalCondition.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static async UniTask PlayEffect(ParticleSystem effect, float duration)
    {
        if (Mathf.Approximately(duration, GameCommonData.InvalidNumber))
        {
            return;
        }

        effect.gameObject.SetActive(true);
        effect.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        if (effect == null)
        {
            return;
        }

        effect.Stop();
        effect.gameObject.SetActive(false);
    }

    private void PlayEffectInActive(ParticleSystem effect, bool isActive)
    {
        effect.gameObject.SetActive(isActive);
        if (isActive)
        {
            effect.Play();
        }
        else
        {
            effect.Stop();
        }
    }


    private void ForceAllEffectStop()
    {
        healEffect.Stop();
        healEffect.gameObject.SetActive(false);
    }
}