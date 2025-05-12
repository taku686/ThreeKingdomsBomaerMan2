using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class EffectActivateUseCase : MonoBehaviour
{
    //Buff
    [SerializeField] private ParticleSystem healEffect;
    [SerializeField] private ParticleSystem hpEffect;
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private ParticleSystem speedEffect;
    [SerializeField] private ParticleSystem bombLimitEffect;
    [SerializeField] private ParticleSystem fireRangeEffect;
    [SerializeField] private ParticleSystem allStatusBuffEffect;
    [SerializeField] private ParticleSystem godPowerEffect;
    [SerializeField] private ParticleSystem barrierEffect;
    [SerializeField] private ParticleSystem skillBarrierEffect;
    [SerializeField] private ParticleSystem perfectBarrierEffect;
    [SerializeField] private ParticleSystem blastReflectionEffect;
    [SerializeField] private ParticleSystem debuffEffect;
    [SerializeField] private ParticleSystem prohibitedSkillEffect;
    [SerializeField] private ParticleSystem slowTimeEffect;

    //AbnormalState
    [SerializeField] private ParticleSystem poisonEffect;
    [SerializeField] private ParticleSystem paralysisEffect;
    [SerializeField] private ParticleSystem confusionEffect;
    [SerializeField] private ParticleSystem frozenEffect;
    [SerializeField] private ParticleSystem fearEffect;

    public void Initialize
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

        ForceAllEffectStop();
    }


    private void ActivateBuffEffect(SkillMasterData skillMasterData)
    {
        switch (skillMasterData.SkillEffectType)
        {
            case SkillEffectType.Heal:
                PlayEffect(healEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.ContinuousHeal:
                PlayEffect(healEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.HpBuff:
                PlayEffect(hpEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.AttackBuff:
                PlayEffect(attackEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.SpeedBuff:
                PlayEffect(speedEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.BombLimitBuff:
                PlayEffect(bombLimitEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.FireRangeBuff:
                PlayEffect(fireRangeEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.AllStatusBuff:
                PlayEffect(allStatusBuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.GodPower:
                PlayEffect(godPowerEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.Barrier:
                PlayEffect(barrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.SkillBarrier:
                PlayEffect(skillBarrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.PerfectBarrier:
                PlayEffect(perfectBarrierEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.BlastReflection:
                PlayEffect(blastReflectionEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.HpDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.AttackDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.SpeedDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.BombLimitDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.FireRangeDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.RandomDebuff:
                PlayEffect(debuffEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.ProhibitedSkill:
                PlayEffect(prohibitedSkillEffect, skillMasterData.EffectTime).Forget();
                break;
            case SkillEffectType.SlowTime:
                PlayEffect(slowTimeEffect, skillMasterData.EffectTime).Forget();
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
        effect.Stop();
        effect.gameObject.SetActive(false);
    }

    private void ForceAllEffectStop()
    {
        healEffect.Stop();
        healEffect.gameObject.SetActive(false);
    }
}