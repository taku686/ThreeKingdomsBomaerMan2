using DG.Tweening;
using Manager.NetworkManager;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using UnityEngine.UI;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class BattleReadyState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.BattleReadyGameObject.SetActive(true);
                InitializeObject();
                InitializeButton();
                InitializeSubscribe();
                Owner.photonNetworkManager.OnStartConnectNetwork();
            }

            private void InitializeObject()
            {
                foreach (var obj in Owner.battleReadyView.GridGameObjectList)
                {
                    obj.SetActive(false);
                }
            }

            private void InitializeButton()
            {
                Owner.battleReadyView.BackButton.onClick.RemoveAllListeners();
                Owner.battleReadyView.BackButton.onClick.AddListener(OnClickBackButton);
            }

            private void InitializeSubscribe()
            {
                Owner.photonNetworkManager.JoinedRoom.Subscribe(OnJoinedRoom)
                    .AddTo(Owner.gameObject);
                Owner.photonNetworkManager.LeftRoom.Subscribe(OnLeftRoom)
                    .AddTo(Owner.gameObject);
            }

            private void OnClickBackButton()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.battleReadyView.BackButton.gameObject)
                    .OnComplete(() =>
                    {
                        if (!PhotonNetwork.InRoom)
                        {
                            return;
                        }

                        PhotonNetwork.LeaveRoom();
                        Owner.DisableTitleGameObject();
                        Owner.mainView.MainGameObject.SetActive(true);
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnJoinedRoom(int index)
            {
                Debug.Log(index);
                var characterData = Owner.photonNetworkManager.CurrentCharacterList[index];
                Owner.battleReadyView.TextList[index].text = characterData.Name;
                Owner.battleReadyView.BackGroundList[index].sprite =
                    Owner._titleModel.GetCharacterColor((int)characterData.CharaColor);
                Owner.battleReadyView.CharacterList[index].sprite =
                    Owner._titleModel.GetCharacterSprite(characterData.ID);
                Owner.battleReadyView.GridGameObjectList[index].gameObject.SetActive(true);
            }

            private void OnLeftRoom(int index)
            {
                Owner.battleReadyView.GridGameObjectList[index].gameObject.SetActive(false);
            }
        }
    }
}