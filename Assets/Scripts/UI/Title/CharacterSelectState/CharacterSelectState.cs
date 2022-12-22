using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
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
                if (Owner._userManager.IsGetCharacter(characterData.ID))
                {
                    CreateActiveGrid(characterData, parent);
                }
                else
                {
                    CreateDisableGrid(characterData, parent);
                }
            }

            // ReSharper disable Unity.PerformanceAnalysis
            private void CreateActiveGrid(CharacterData characterData, Transform parent)
            {
                var grid = Instantiate(Owner.characterSelectView.Grid, parent);
                var characterGrid = grid.GetComponentInChildren<CharacterGrid>();
                characterGrid.characterImage.sprite = Owner._characterDataManager.GetCharacterSprite(characterData.ID);
                characterGrid.backGroundImage.sprite = Owner._characterDataManager.GetCharacterColor(
                    (int)GameSettingData.GetCharacterColor(characterData.CharaColor));
                characterGrid.nameText.text = characterData.Name;
                characterGrid.CharacterData = characterData;
                characterGrid.gridButton.onClick.AddListener(() => { OnClickCharacterGrid(characterData, grid); });
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(Owner.characterSelectView.GridDisable, parent)
                    .GetComponent<CharacterDisableGrid>();
                disableGrid.characterImage.color = Color.black;
                disableGrid.characterImage.sprite = Owner._characterDataManager.GetCharacterSprite(characterData.ID);
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
                    Owner._characterDataManager.GetCharacterGameObject(characterData.ID),
                    characterCreatePosition.position,
                    characterCreatePosition.rotation, characterCreatePosition);
                Owner._currentCharacterId = characterData.ID;
                Owner._uiAnimation.OnClickScaleAnimation(gridGameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterDetail); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.characterSelectView.BackButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.DisableTitleGameObject();
                        Owner.mainView.MainGameObject.SetActive(true);
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(GameObject disableGrid, int characterId, CancellationToken token)
            {
                Owner._uiAnimation.OnClickScaleAnimation(disableGrid).OnComplete(() =>
                    UniTask.Void(async () =>
                    {
                        var user = Owner._userManager.GetUser();
                        var characterPrice = GameSettingData.CharacterPrice;
                        var diamond = user.Gem;
                        if (diamond < characterPrice)
                        {
                            Owner.characterSelectView.GemAddPopup.gameObject.SetActive(true);
                            return;
                        }

                        var itemName = characterId.ToString();
                        var virtualCurrencyKey = GameSettingData.GemKey;
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
                        user.Characters[characterId] = Owner._characterDataManager.GetCharacterData(characterId);
                        var isSuccessUpdatePlayerData = await Owner._playFabPlayerDataManager
                            .TryUpdateUserDataAsync(GameSettingData.UserKey, user)
                            .AttachExternalCancellation(token);
                        if (!isSuccessUpdatePlayerData)
                        {
                            return;
                        }

                        Owner._userManager.SetUser(user);
                        CreateUIContents();
                    })).SetLink(disableGrid.gameObject);
            }

            private void OnClickClosePopup()
            {
                var closeButton = Owner.characterSelectView.GemAddPopup.CloseButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(closeButton)
                    .OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickCancelPurchase()
            {
                var cancelButton = Owner.characterSelectView.GemAddPopup.CancelButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(cancelButton)
                    .OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickAddGem()
            {
                var addButton = Owner.characterSelectView.GemAddPopup.AddButton.gameObject;
                var popup = Owner.characterSelectView.GemAddPopup.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(addButton).OnComplete(() =>
                    {
                        Owner._stateMachine.Dispatch((int)Event.Shop);
                    })
                    .SetLink(popup);
            }
        }
    }
}