using Cysharp.Threading.Tasks;
using UnityEngine;

public class LevelUpView : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private ParticleSystem _levelUpParticle;
    [SerializeField] private GameObject _levelUpText;


    public async UniTask ShowLevelUpEffect()
    {
        var effectDuration = _levelUpParticle.main.duration;
        var particleObj = Instantiate(_levelUpParticle, _targetTransform.position, _targetTransform.rotation);
        var textObj = Instantiate(_levelUpText, _targetTransform.position, _targetTransform.rotation);

        await UniTask.Delay((int)(effectDuration * 1000)); // Convert seconds to milliseconds

        Destroy(particleObj.gameObject);
        Destroy(textObj);
    }
}