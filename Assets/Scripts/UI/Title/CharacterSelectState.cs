using System.Collections.Generic;
using Common.Data;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
                InitializeButton();
            }

            private void InitializeButton()
            {
                Owner.characterSelectView.BackButton.onClick.RemoveAllListeners();
                Owner.characterSelectView.BackButton.onClick.AddListener(OnClickBack);
            }

            private void CreateUIContents()
            {
                foreach (var gridGroupList in _gridGroupLists)
                {
                    Destroy(gridGroupList);
                }

                _gridGroupLists.Clear();
                GameObject gridGroup = null;
                for (int i = 0; i < Owner._characterDataModel.GetCharacterCount(); i++)
                {
                    if (i % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        _gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        SetupGrip(Owner._characterDataModel.GetCharacterData(i), gridGroup.transform);
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

            private void CreateActiveGrid(CharacterData characterData, Transform parent)
            {
                var grid = Instantiate(Owner.characterSelectView.Grid, parent);
                grid.GetComponentInChildren<CharacterGrid>().characterData = characterData;
                var images = grid.GetComponentsInChildren<Image>();
                var names = grid.GetComponentsInChildren<TextMeshProUGUI>();
                var button = grid.GetComponent<Button>();
                button.onClick.AddListener(OnClickCharacterGrid);
                foreach (var image in images)
                {
                    if (image.CompareTag("CharacterImage"))
                    {
                        image.sprite = Owner._characterDataModel.GetCharacterSprite(characterData.ID);
                    }

                    if (image.CompareTag("BackGround"))
                    {
                        image.sprite =
                            Owner._characterDataModel.GetCharacterColor(
                                (int)GameSettingData.GetCharacterColor(characterData.CharaColor));
                    }
                }

                foreach (var name in names)
                {
                    if (name.CompareTag("Name"))
                    {
                        name.text = characterData.Name;
                    }
                }
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var images = Instantiate(Owner.characterSelectView.GridDisable, parent)
                    .GetComponentsInChildren<Image>();
                foreach (var image in images)
                {
                    if (image.gameObject.CompareTag("CharacterImage"))
                    {
                        image.color = Color.black;
                        image.sprite = Owner._characterDataModel.GetCharacterSprite(characterData.ID);
                    }
                }
            }

            private void OnClickCharacterGrid()
            {
                PointerEventData pointer = new PointerEventData(EventSystem.current);
                pointer.position = Input.mousePosition;
                List<RaycastResult> result = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointer, result);

                foreach (RaycastResult raycastResult in result)
                {
                    if (raycastResult.gameObject.CompareTag("Button"))
                    {
                        var characterCreatePosition = Owner.characterCreatePosition;
                        var preCharacter = Owner._character;
                        Destroy(preCharacter);
                        var characterData = raycastResult.gameObject.GetComponent<CharacterGrid>().characterData;
                        Owner._character = Instantiate(
                            Owner._characterDataModel.GetCharacterGameObject(characterData.ID),
                            characterCreatePosition.position,
                            characterCreatePosition.rotation, characterCreatePosition);
                        Owner._currentCharacterId = characterData.ID;
                        Owner._uiAnimation.OnClickScaleAnimation(raycastResult.gameObject)
                            .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterDetail); })
                            .SetLink(Owner.gameObject);
                    }
                }
            }

            private void OnClickBack()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.characterSelectView.BackButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.DisableTitleGameObject();
                        Owner.mainView.MainGameObject.SetActive(true);
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}