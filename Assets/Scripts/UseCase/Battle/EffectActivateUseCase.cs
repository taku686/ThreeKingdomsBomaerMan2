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
    [SerializeField] private ParticleSystem godPowerEffect;

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
            .Subscribe(ActivateBuffEffect)
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
        }
    }

    private async UniTask PlayEffect(ParticleSystem effect, float duration)
    {
        effect.gameObject.SetActive(true);
        effect.Play();
        await UniTask.Delay((int)(duration * 1000));
        effect.Stop();
        effect.gameObject.SetActive(false);
    }

    private void ForceAllEffectStop()
    {
        healEffect.Stop();
        healEffect.gameObject.SetActive(false);
    }
}