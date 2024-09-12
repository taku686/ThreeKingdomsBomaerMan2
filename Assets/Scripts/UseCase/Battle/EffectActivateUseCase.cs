using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class EffectActivateUseCase : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect;

    public void Initialize
    (
        IObservable<(int, SkillMasterData)> onSkillActivate,
        int actorNumber
    )
    {
        onSkillActivate
            .Where(tuple => tuple.Item1 == actorNumber)
            .Select(tuple => tuple.Item2)
            .Subscribe(Activate)
            .AddTo(gameObject.GetCancellationTokenOnDestroy());

        ForceAllEffectStop();
    }


    private void Activate(SkillMasterData skillMasterData)
    {
        switch (skillMasterData.SkillEffectType)
        {
            case SkillEffectType.Heal:
                PlayEffect(healEffect, skillMasterData.EffectTime).Forget();
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