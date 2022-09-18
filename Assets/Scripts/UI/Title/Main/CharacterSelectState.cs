using Common.Data;
using UnityEngine;
using UnityEngine.UI;
using State = StateMachine<UI.Title.Main.TitlePresenter>.State;

namespace UI.Title.Main
{
    public partial class TitlePresenter
    {
        public class CharacterSelectState : StateMachine<TitlePresenter>.State
        {
            //   private readonly List<GameObject> _groupLists = new List<GameObject>();

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
            }

            protected override void OnUpdate()
            {
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                CreateUIContents();
            }

            private void CreateUIContents()
            {
                GameObject gridGroup = null;
                Debug.Log(Owner._titleModel.GetCharacterCount());
                for (int i = 0; i < Owner._titleModel.GetCharacterCount(); i++)
                {
                    if (i % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        // _groupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        SetupGrip(Owner._titleModel.GetCharacterData(i), gridGroup.transform);
                    }
                }
            }

            private void SetupGrip(CharacterData characterData, Transform parent)
            {
                if (!characterData.IsLock)
                {
                    
                    var grid = Instantiate(Owner.characterSelectView.Grid, parent);
                    var images = grid.GetComponentsInChildren<Image>();
                    var button = grid.GetComponent<Button>();
                    button.onClick.AddListener(()=> Owner._stateMachine.Dispatch((int)Event.CharacterDetail));
                    foreach (var image in images)
                    {
                        if (image.gameObject.CompareTag("CharacterImage"))
                        {
                            image.sprite = Owner._titleModel.GetCharacterSprite(characterData.ID);
                        }

                        if (image.gameObject.CompareTag("BackGround"))
                        {
                            image.sprite = Owner._titleModel.GetCharacterColor((int)characterData.CharaColor);
                        }
                    }
                }
                else
                {
                    var images = Instantiate(Owner.characterSelectView.GridDisable, parent)
                        .GetComponentsInChildren<Image>();
                    foreach (var image in images)
                    {
                        if (image.gameObject.CompareTag("CharacterImage"))
                        {
                            image.color = Color.black;
                            image.sprite = Owner._titleModel.GetCharacterSprite(characterData.ID);
                        }
                    }
                }
            }
        }
    }
}