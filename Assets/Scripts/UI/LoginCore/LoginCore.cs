using System.Threading;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using MoreMountains.Tools;
using UI.Common;
using UI.Title;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoginCore : MonoBehaviour
{
    [Inject] private UIAnimation _uiAnimation;
    [Inject] private PlayFabLoginManager _playFabLoginManager;
    [Inject] private PopupGenerateUseCase _popupGenerateUseCase;
    [Inject] private PlayFabUserDataManager _playFabUserDataManager;
    [SerializeField] private GameObject _blockPanel;
    [SerializeField] private LoginView _loginView;
    [SerializeField] private CommonView _commonView;
    private CancellationTokenSource _cancellationTokenSource;


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _blockPanel.SetActive(false);
        _cancellationTokenSource = new CancellationTokenSource();
        Subscribe();
    }

    private void Subscribe()
    {
        _loginView._LoginButton
            .OnClickAsObservable()
            .SelectMany(_ => OnClickScaleColorAnimation(_loginView._LoginButton).ToObservable())
            .SelectMany(_ => Login().ToObservable())
            .Subscribe()
            .AddTo(_cancellationTokenSource.Token);
    }

    private async UniTask OnClickScaleColorAnimation(Button button)
    {
        _blockPanel.SetActive(true);
        await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
    }

    private async UniTask Login()
    {
        _commonView.waitPopup.SetActive(true);
        _playFabLoginManager.Initialize();
        var result = await _playFabLoginManager.Login().AttachExternalCancellation(_cancellationTokenSource.Token);
        var loginResult = result.Item1;
        if (loginResult.Error != null)
        {
            _commonView.waitPopup.SetActive(false);
            _blockPanel.SetActive(false);
            return;
        }

        if (!loginResult.Result.InfoResultPayload.UserData.ContainsKey(GameCommonData.UserKey))
        {
            var checkDisplayName =
                _popupGenerateUseCase
                    .GenerateInputNamePopup("名前を入力してください", "")
                    .SelectMany(displayName => ValidationCheck(displayName).ToObservable())
                    .Publish();

            checkDisplayName
                .Where(tuple => !tuple.Item1)
                .SelectMany(_ => _popupGenerateUseCase.GenerateErrorPopup("適切な名前を入力してください", "OK"))
                .Subscribe(_ =>
                {
                    _blockPanel.SetActive(false);
                    _commonView.waitPopup.SetActive(false);
                })
                .AddTo(_cancellationTokenSource.Token);

            checkDisplayName
                .Where(tuple => tuple.Item1)
                .SelectMany(tuple => _playFabLoginManager.Login(tuple.Item2).ToObservable())
                .SelectMany(tuple => _playFabLoginManager.CreateUserData(tuple).ToObservable())
                .SelectMany(response => _playFabLoginManager.InitializeGameData(response).ToObservable())
                .Subscribe(_ =>
                {
                    MMSceneLoadingManager.LoadScene(GameCommonData.MainScene);
                    _commonView.waitPopup.SetActive(false);
                })
                .AddTo(_cancellationTokenSource.Token);

            checkDisplayName.Connect().AddTo(_cancellationTokenSource.Token);
        }
        else
        {
            await _playFabLoginManager.InitializeGameData(loginResult);
            MMSceneLoadingManager.LoadScene(GameCommonData.MainScene);
            _commonView.waitPopup.SetActive(false);
        }
    }

    private async UniTask<(bool, string)> ValidationCheck(string displayName)
    {
        _commonView.waitPopup.SetActive(true);
        var result = await _playFabUserDataManager.UpdateUserDisplayNameAsync(displayName);
        return result;
    }
}