using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public abstract class PopupBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleTMP;
    [SerializeField] private TextMeshProUGUI _explanationText;
    [Inject] private BlockingGameObject _blockingImageObject;
    private const float Duration = 0.2f;

    public virtual async UniTask Open(ViewModel viewModel)
    {
        _blockingImageObject.gameObject.SetActive(true);
        ApplyViewModel(viewModel);
        transform.localScale = Vector3.zero;
        await transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutBack)
            .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
    }

    public virtual async UniTask Close()
    {
        await transform.DOScale(Vector3.zero, Duration).SetEase(Ease.InBack)
            .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        Destroy(gameObject);
        _blockingImageObject.gameObject.SetActive(false);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        if (_titleTMP != null)
        {
            _titleTMP.text = viewModel._Title;
        }

        if (_explanationText != null)
        {
            _explanationText.text = viewModel._Explanation;
        }
    }

    public class ViewModel : IDisposable
    {
        public string _Title { get; }
        public string _Explanation { get; }

        protected ViewModel
        (
            string titleText,
            string explanationText
        )
        {
            _Title = titleText;
            _Explanation = explanationText;
        }

        public void Dispose()
        {
        }
    }
}