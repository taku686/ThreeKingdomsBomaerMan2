using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public abstract class PopupBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
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
        _titleText.text = viewModel.Title;
        _explanationText.text = viewModel.Explanation;
    }

    public class ViewModel
    {
        public string Title { get; }
        public string Explanation { get; }

        protected ViewModel
        (
            string titleText,
            string explanationText
        )
        {
            Title = titleText;
            Explanation = explanationText;
        }
    }
}