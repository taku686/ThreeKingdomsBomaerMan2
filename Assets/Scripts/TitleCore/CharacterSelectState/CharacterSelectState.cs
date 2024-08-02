using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UniRx;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterSelectState : State
        {
            private readonly List<GameObject> gridGroupLists = new();
            private UserDataManager userDataManager;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private bool isProcessing;
            private CancellationTokenSource cancellationTokenSource;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                SetupUi();
                SetupCancellationToken();
                userDataManager = Owner.userDataManager;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                CreateUIContents();
                InitializeButton();
                Owner.SwitchUiObject(TitleCoreEvent.CharacterSelect, true);
            }

            private void SetupUi()
            {
                Owner.characterSelectView.ContentsTransform.anchoredPosition =
                    new Vector2(Owner.characterSelectView.ContentsTransform.anchoredPosition.x, 0);
            }

            private void SetupCancellationToken()
            {
                if (cancellationTokenSource != null)
                {
                    return;
                }

                cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.RegisterRaiseCancelOnDestroy(Owner);
            }

            private void InitializeButton()
            {
                Owner.characterSelectView.BackButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickBack())
                    .AddTo(cancellationTokenSource.Token);
                Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickCancelPurchase())
                    .AddTo(cancellationTokenSource.Token);
                Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickClosePopup())
                    .AddTo(cancellationTokenSource.Token);
                Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickAddGem())
                    .AddTo(cancellationTokenSource.Token);
            }


            private void CreateUIContents()
            {
                foreach (var gridGroupList in gridGroupLists)
                {
                    Destroy(gridGroupList);
                }

                gridGroupLists.Clear();
                GameObject gridGroup = null;
                for (int i = 0; i < Owner.characterDataManager.GetCharacterCount(); i++)
                {
                    if (i % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        SetupGrip(Owner.characterDataManager.GetCharacterData(i), gridGroup.transform);
                    }
                }
            }

            private void SetupGrip(CharacterData characterData, Transform parent)
            {
                if (Owner.userDataManager.IsGetCharacter(characterData.Id))
                {
                    CreateActiveGrid(characterData, parent);
                }
                else
                {
                    CreateDisableGrid(characterData, parent);
                }
            }

            private void CreateActiveGrid(CharacterData characterData, Transform parent)
            {
                var grid = Instantiate(Owner.characterSelectView.Grid, parent);
                var characterGrid = grid.GetComponentInChildren<CharacterGrid>();
                var levelData = userDataManager.GetCurrentLevelData(characterData.Id);
                characterGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                characterGrid.backGroundImage.sprite = characterData.ColorSprite;
                characterGrid.nameText.text = characterData.Name;
                characterGrid.CharacterData = characterData;
                characterGrid.levelText.text = GameCommonData.LevelText + levelData.Level;
                characterGrid.gridButton.onClick.AddListener(() => { OnClickCharacterGrid(characterData, grid); });
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(Owner.characterSelectView.GridDisable, parent)
                    .GetComponent<CharacterDisableGrid>();
                disableGrid.characterImage.color = Color.black;
                disableGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                disableGrid.purchaseButton.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        OnClickPurchaseButton(disableGrid.gameObject, characterData,
                            disableGrid.GetCancellationTokenOnDestroy());
                    })
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());
            }

            private void OnClickCharacterGrid(CharacterData characterData, GameObject gridGameObject)
            {
                if (isProcessing)
                {
                    return;
                }

                isProcessing = true;
                var result = Owner.CreateCharacter(characterData.Id);
                if (!result)
                {
                    isProcessing = false;
                    return;
                }

                Owner.uiAnimation.ClickScale(gridGameObject).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.CharacterDetail);
                    isProcessing = false;
                }).SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.characterSelectView.BackButton.gameObject).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(GameObject disableGrid, CharacterData characterData,
                CancellationToken token)
            {
                if (isProcessing)
                {
                    return;
                }

                isProcessing = true;
                Owner.uiAnimation.ClickScale(disableGrid).OnComplete(() => UniTask.Void(async () =>
                {
                    var user = Owner.userDataManager.GetUserData();
                    var characterPrice = GameCommonData.CharacterPrice;
                    var gem = await playFabVirtualCurrencyManager.GetGem();
                    if (gem == GameCommonData.NetworkErrorCode)
                    {
                        isProcessing = false;
                        return;
                    }

                    if (gem < characterPrice)
                    {
                        Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject.SetActive(true);
                        isProcessing = false;
                        return;
                    }

                    if (user.Characters.Contains(characterData.Id))
                    {
                        isProcessing = false;
                        return;
                    }

                    var virtualCurrencyKey = GameCommonData.GemKey;
                    var price = characterPrice;
                    var isSuccessPurchase = await Owner.playFabShopManager
                        .TryPurchaseCharacter(characterData.Id, virtualCurrencyKey, price)
                        .AttachExternalCancellation(token);
                    if (!isSuccessPurchase)
                    {
                        //todo 購入に失敗したときの処理
                        isProcessing = false;
                        return;
                    }

                    await Owner.SetGemText();
                    await Owner.SetRewardUI(1, characterData.SelfPortraitSprite);
                    CreateUIContents();
                    isProcessing = false;
                })).SetLink(disableGrid.gameObject);
            }

            private void OnClickClosePopup()
            {
                var closeButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(closeButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickCancelPurchase()
            {
                var cancelButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(cancelButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickAddGem()
            {
                var addButton = Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(addButton)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)TitleCoreEvent.Shop); }).SetLink(popup);
            }

            private void Cancel()
            {
                if (cancellationTokenSource == null)
                {
                    return;
                }

                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}