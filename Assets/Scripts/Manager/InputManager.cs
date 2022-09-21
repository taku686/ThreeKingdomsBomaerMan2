using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private readonly ReactiveProperty<Vector3>
            _moveDirection = new ReactiveProperty<Vector3>(Vector3.zero);

        private bool _isSetup;
        private PhotonView _photonView;
        public ReactiveProperty<Vector3> MoveDirection => _moveDirection;

        public void Initialize(PhotonView photonView)
        {
            _photonView = photonView;
            _isSetup = true;
        }

        private void Update()
        {
            if (!_isSetup || !_photonView.IsMine)
            {
                return;
            }
            _moveDirection.SetValueAndForceNotify(
                new Vector3Int((int)Input.GetAxisRaw("Horizontal"), 0, (int)Input.GetAxisRaw("Vertical")));
        }
    }
}