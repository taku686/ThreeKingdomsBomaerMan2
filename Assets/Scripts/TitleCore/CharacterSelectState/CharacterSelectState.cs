using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterSelectState : State
        {
            private readonly List<GameObject> _gridGroupLists = new();
            private UserDataManager _userDataManager;
            private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
            private bool _isProcessing;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _userDataManager = Owner._userDataManager;
                _playFabVirtualCurrencyManager = Owner._playFabVirtualCurrencyManager;
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                CreateUIContents();
                InitializePopup();
                InitializeButton();
            }

            private void InitializeButton()
            {
                Owner.characterSelectView.BackButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.BackButton.onClick.AddListener(OnClickBack);
                Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.onClick.AddListener(
                    OnClickCancelPurchase);
                Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.onClick.AddListener(OnClickClosePopup);
                Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.onClick.AddListener(OnClickAddGem);
            }

            private void InitializePopup()
            {
                Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject.SetActive(false);
            }

            private void CreateUIContents()
            {
                foreach (var gridGroupList in _gridGroupLists)
                {
                    Destroy(gridGroupList);
                }

                _gridGroupLists.Clear();
                GameObject gridGroup = null;
                for (int i = 0; i < Owner._characterDataManager.GetCharacterCount(); i++)
                {
                    if (i % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        _gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        SetupGrip(Owner._characterDataManager.GetCharacterData(i), gridGroup.transform);
                    }
                }
            }

            private void SetupGrip(CharacterData characterData, Transform parent)
            {
                if (Owner._userDataManager.IsGetCharacter(characterData.Id))
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
                var levelData = _userDataManager.GetCurrentLevelData(characterData.Id);
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
                disableGrid.purchaseButton.onClick.AddListener(() =>
                    OnClickPurchaseButton(disableGrid.gameObject, characterData,
                        disableGrid.GetCancellationTokenOnDestroy()));
            }

            private void OnClickCharacterGrid(CharacterData characterData, GameObject gridGameObject)
            {
                if (_isProcessing)
                {
                    return;
                }

                _isProcessing = true;
                var result = Owner.CreateCharacter(characterData.Id);
                if (!result)
                {
                    _isProcessing = false;
                    return;
                }

                Owner._uiAnimation.ClickScale(gridGameObject).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.CharacterDetail);
                    _isProcessing = false;
                }).SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.characterSelectView.BackButton.gameObject).OnComplete(() =>
                {
                    Owner.DisableTitleGameObject();
                    Owner.mainView.MainGameObject.SetActive(true);
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(GameObject disableGrid, CharacterData characterData,
                CancellationToken token)
            {
                if (_isProcessing)
                {
                    return;
                }

                _isProcessing = true;
                Owner._uiAnimation.ClickScale(disableGrid).OnComplete(() => UniTask.Void(async () =>
                {
                    var user = Owner._userDataManager.GetUserData();
                    var characterPrice = GameCommonData.CharacterPrice;
                    var gem = await _playFabVirtualCurrencyManager.GetGem();
                    if (gem == GameCommonData.NetworkErrorCode)
                    {
                        _isProcessing = false;
                        return;
                    }

                    if (gem < characterPrice)
                    {
                        Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject.SetActive(true);
                        _isProcessing = false;
                        return;
                    }

                    if (user.Characters.Contains(characterData.Id))
                    {
                        _isProcessing = false;
                        return;
                    }

                    var virtualCurrencyKey = GameCommonData.GemKey;
                    var price = characterPrice;
                    var isSuccessPurchase = await Owner._playFabShopManager
                        .TryPurchaseCharacter(characterData.Id, virtualCurrencyKey, price)
                        .AttachExternalCancellation(token);
                    if (!isSuccessPurchase)
                    {
                        //todo 購入に失敗したときの処理
                        _isProcessing = false;
                        return;
                    }

                    await Owner.SetGemText();
                    await Owner.SetRewardUI(1, characterData.SelfPortraitSprite);
                    CreateUIContents();
                    _isProcessing = false;
                })).SetLink(disableGrid.gameObject);
            }

            private void OnClickClosePopup()
            {
                var closeButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(closeButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickCancelPurchase()
            {
                var cancelButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(cancelButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickAddGem()
            {
                var addButton = Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(addButton)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Shop); }).SetLink(popup);
            }
        }
    }
}