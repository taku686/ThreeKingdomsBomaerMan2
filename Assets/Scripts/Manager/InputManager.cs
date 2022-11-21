using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UI.Common;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputView _inputView;
        private readonly ReactiveProperty<Vector3>
            _moveDirection = new ReactiveProperty<Vector3>(Vector3.zero);

        private readonly Subject<Tuple<int, int>> _putBombSubject = new Subject<Tuple<int, int>>();
        private string _joystickName;
        private PhotonView _photonView;
        private CancellationToken _token;
        private Button _bombButton;
        public ReactiveProperty<Vector3> MoveDirection => _moveDirection;
        public IObservable<Tuple<int, int>> PutBombIObservable => _putBombSubject;

        public void Initialize(PhotonView photonView)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _photonView = photonView;
            _joystickName = GameSettingData.JoystickName;
            _inputView = FindObjectOfType<InputView>();
            _bombButton = _inputView.bombButton;
            if (!_photonView.IsMine)
            {
                return;
            }

            Observable.EveryUpdate().Subscribe(_ =>
            {
                _moveDirection.SetValueAndForceNotify(
                    new Vector3(UltimateJoystick.GetHorizontalAxis(_joystickName), 0,
                        UltimateJoystick.GetVerticalAxis(_joystickName)));
            }).AddTo(_token);
            SetupInputPutBomb();
        }

        private void SetupInputPutBomb()
        {
            _bombButton.OnClickAsObservable().Throttle(TimeSpan.FromSeconds(0.2f))
                .Subscribe(
                    _ =>
                    {
                        var playerId = _photonView.ViewID;
                        var explosionTime = PhotonNetwork.ServerTimestamp +
                                            GameSettingData.ThreeMilliSecondsBeforeExplosion;
                        var tuple = new Tuple<int, int>(playerId, explosionTime);
                        _putBombSubject.OnNext(tuple);
                    }).AddTo(_token);
        }

        private void OnDestroy()
        {
            _moveDirection.Dispose();
            _putBombSubject.Dispose();
        }
    }
}