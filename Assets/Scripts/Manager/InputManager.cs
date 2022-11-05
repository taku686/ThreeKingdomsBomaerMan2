using Common.Data;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private readonly ReactiveProperty<Vector3>
            _moveDirection = new ReactiveProperty<Vector3>(Vector3.zero);

        private string _joystickName;
        private bool _isSetup;
        private PhotonView _photonView;
        public ReactiveProperty<Vector3> MoveDirection => _moveDirection;

        public void Initialize(PhotonView photonView)
        {
            _photonView = photonView;
            _isSetup = true;
            _joystickName = GameSettingData.JoystickName;
        }

        private void Update()
        {
            if (!_isSetup || !_photonView.IsMine)
            {
                return;
            }

            _moveDirection.SetValueAndForceNotify(
                new Vector3(UltimateJoystick.GetHorizontalAxis(_joystickName), 0,
                    UltimateJoystick.GetVerticalAxis(_joystickName)));
        }
    }
}