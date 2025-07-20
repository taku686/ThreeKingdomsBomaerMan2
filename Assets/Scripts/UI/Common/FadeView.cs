using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FadeView : MonoBehaviour
{
    [SerializeField] private Texture[] _maskTextures;
    [SerializeField] private Sprite[] _backgroundSprites;
    [SerializeField] private Image _fadeImage;
    [SerializeField, Range(-0.1f, 1.1f)] private float _cutoutRange;
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private float _stopDuration = 0.5f;
    private Material _fadeMaterial;
    private static readonly int FadeAmount = Shader.PropertyToID("_FadeAmount");
    private static readonly int FadeTexture = Shader.PropertyToID("_FadeTex");

    public float _Range
    {
        get => _cutoutRange;
        set
        {
            _cutoutRange = value;
            UpdateMaskCutout(_cutoutRange);
        }
    }

    public void Initialize()
    {
        _fadeMaterial = _fadeImage.material;
        _fadeImage.sprite = GetRandomBackgroundSprite();
        _fadeMaterial.SetTexture(FadeTexture, GetRandomMaskTexture());
        _Range = 0f; // Start with a fully faded state
    }


    public async UniTask FadeOutAsync()
    {
        var endTime = Time.timeSinceLevelLoad + _fadeDuration * _cutoutRange;

        while (Time.timeSinceLevelLoad <= endTime)
        {
            _Range = (endTime - Time.timeSinceLevelLoad) / _fadeDuration;
            await UniTask.Yield();
        }

        _cutoutRange = 0;
        _Range = _cutoutRange;
        gameObject.SetActive(false);
    }

    public async UniTask FadeInAsync()
    {
        gameObject.SetActive(true);
        _fadeImage.sprite = GetRandomBackgroundSprite();
        _fadeMaterial.SetTexture(FadeTexture, GetRandomMaskTexture());
        var endTime = Time.timeSinceLevelLoad + _fadeDuration * (1.1f - _cutoutRange);

        while (Time.timeSinceLevelLoad <= endTime)
        {
            _Range = 1 - (endTime - Time.timeSinceLevelLoad) / _fadeDuration;
            await UniTask.Yield();
        }
        
        _cutoutRange = 1.1f;
        _Range = _cutoutRange;
        await UniTask.Delay(TimeSpan.FromSeconds(_stopDuration));
    }

    private void UpdateMaskCutout(float range)
    {
        _fadeMaterial.SetFloat(FadeAmount, 1 - range);
    }

    private Sprite GetRandomBackgroundSprite()
    {
        return _backgroundSprites[Random.Range(0, _backgroundSprites.Length)];
    }

    private Texture GetRandomMaskTexture()
    {
        return _maskTextures[Random.Range(0, _maskTextures.Length)];
    }

    private void OnDestroy()
    {
    }
}