using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterSelectState : State
        {
            private readonly List<GameObject> _gridGroupLists = new List<GameObject>();

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
            }


            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                CreateUIContents();
                InitializePopup();
                InitializeButton();
            }

            private void InitializeButton()
            {
                Owner.characterSelectView.BackButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.GemAddPopup.AddButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.GemAddPopup.CloseButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.GemAddPopup.CancelButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.BackButton.onClick.AddListener(OnClickBack);
                Owner.characterSelectView.GemAddPopup.CancelButton.onClick.AddListener(OnClickCancelPurchase);
                Owner.characterSelectView.GemAddPopup.CloseButton.onClick.AddListener(OnClickClosePopup);
                Owner.characterSelectView.GemAddPopup.AddButton.onClick.AddListener(OnClickAddGem);
            }

            private void InitializePopup()
            {
                Owner.characterSelectView.GemAddPopup.gameObject.SetActive(false);
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
                if (Owner._userDataManager.IsGetCharacter(characterData.ID))
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
                characterGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                characterGrid.backGroundImage.sprite = characterData.ColorSprite;
                characterGrid.nameText.text = characterData.Name;
                characterGrid.CharacterData = characterData;
                characterGrid.gridButton.onClick.AddListener(() => { OnClickCharacterGrid(characterData, grid); });
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(Owner.characterSelectView.GridDisable, parent)
                    .GetComponent<CharacterDisableGrid>();
                disableGrid.characterImage.color = Color.black;
                disableGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                disableGrid.purchaseButton.onClick.AddListener(() =>
                    OnClickPurchaseButton(disableGrid.gameObject, characterData.ID,
                        disableGrid.GetCancellationTokenOnDestroy()));
            }

            private void OnClickCharacterGrid(CharacterData characterData, GameObject gridGameObject)
            {
                var characterCreatePosition = Owner.characterCreatePosition;
                var preCharacter = Owner._character;
                Destroy(preCharacter);
                Owner._character = Instantiate(
                    characterData.CharacterObject,
                    characterCreatePosition.position,
                    characterCreatePosition.rotation, characterCreatePosition);
                Owner._currentCharacterId = characterData.ID;
                Owner._uiAnimation.ClickScale(gridGameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterDetail); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.characterSelectView.BackButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.DisableTitleGameObject();
                        Owner.mainView.MainGameObject.SetActive(true);
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(GameObject disableGrid, int characterId, CancellationToken token)
            {
                Owner._uiAnimation.ClickScale(disableGrid).OnComplete(() =>
                    UniTask.Void(async () =>
                    {
                        var user = Owner._userDataManager.GetUser();
                        var characterPrice = GameCommonData.CharacterPrice;
                        var diamond = user.Gem;
                        if (diamond < characterPrice)
                        {
                            Owner.characterSelectView.GemAddPopup.gameObject.SetActive(true);
                            return;
                        }

                        var itemName = characterId.ToString();
                        var virtualCurrencyKey = GameCommonData.GemKey;
                        var price = characterPrice;
                        var isSuccessPurchase = await Owner._playFabShopManager
                            .TryPurchaseCharacter(itemName, virtualCurrencyKey, price)
                            .AttachExternalCancellation(token);
                        if (!isSuccessPurchase)
                        {
                            //todo 購入に失敗したときの処理
                            return;
                        }

                        user.Gem -= characterPrice;
                        if (user.Characters.Contains(characterId))
                        {
                            return;
                        }

                        user.Characters.Add(characterId);
                        var isSuccessUpdatePlayerData = await Owner._playFabPlayerDataManager
                            .TryUpdateUserDataAsync(GameCommonData.UserKey, user)
                            .AttachExternalCancellation(token);
                        if (!isSuccessUpdatePlayerData)
                        {
                            return;
                        }

                        Owner._userDataManager.SetUser(user);
                        CreateUIContents();
                    })).SetLink(disableGrid.gameObject);
            }

            private void OnClickClosePopup()
            {
                var closeButton = Owner.characterSelectView.GemAddPopup.CloseButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(closeButton)
                    .OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickCancelPurchase()
            {
                var cancelButton = Owner.characterSelectView.GemAddPopup.CancelButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(cancelButton)
                    .OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickAddGem()
            {
                var addButton = Owner.characterSelectView.GemAddPopup.AddButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.ClickScaleColor(addButton).OnComplete(() =>
                    {
                        Owner._stateMachine.Dispatch((int)Event.Shop);
                    })
                    .SetLink(popup);
            }
        }
    }
}