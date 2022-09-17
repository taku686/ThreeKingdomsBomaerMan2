using Cysharp.Threading.Tasks;
using Manager.BattleManager;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PhotonNetworkManager : MonoBehaviourPunCallbacks
    {
        [Inject] private PlayerManager _playerManager;

        public void OnStartConnectNetwork()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            _playerManager.GenerateCharacter().Forget();
        }
    }
}