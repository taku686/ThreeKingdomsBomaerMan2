using System;
using System.Collections.Generic;
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
        private static readonly float InputBombInterval = 0.05f;
        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;

        private readonly ReactiveProperty<Vector3>
            _moveDirection = new ReactiveProperty<Vector3>(Vector3.zero);

        private readonly Subject<Tuple<int, int>> _putBombSubject = new Subject<Tuple<int, int>>();
        private string _joystickName;
        private PhotonView _photonView;
        private CancellationToken _token;
        private Button _bombButton;
        private Image _skillOneIntervalImage;
        private Image _skillTwoIntervalImage;
        private float _timerSkillOne = 0;
        private float _timerSkillTwo = 0;
        public ReactiveProperty<Vector3> MoveDirection => _moveDirection;
        public IObservable<Tuple<int, int>> PutBombIObservable => _putBombSubject;


        public void Initialize(PhotonView photonView, float skillOneIntervalTime, float skillTwoIntervalTime)
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

            _skillOneIntervalImage = _inputView.skillOneIntervalImage;
            _skillTwoIntervalImage = _inputView.skillTwoIntervalImage;
            SetupSkillUI(skillOneIntervalTime, skillTwoIntervalTime);
            SetupInputMove();
            SetupInputPutBomb();
        }

        private void SetupInputMove()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                _moveDirection.SetValueAndForceNotify(
                    new Vector3(UltimateJoystick.GetHorizontalAxis(_joystickName), 0,
                        UltimateJoystick.GetVerticalAxis(_joystickName)));
            }).AddTo(_token);
        }

        private void SetupInputPutBomb()
        {
            _bombButton.OnClickAsObservable().Throttle(TimeSpan.FromSeconds(InputBombInterval))
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

        public void SetOnClickSkillOne(float intervalTime, Action action)
        {
            _inputView.skillOneButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime)).Subscribe(
                _ =>
                {
                    ResetSkillOneIntervalImage();
                    action.Invoke();
                }).AddTo(_token);
        }

        public void SetOnClickSkillTwo(float intervalTime, Action action)
        {
            _inputView.skillTwoButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime))
                .Subscribe(_ =>
                {
                    ResetSkillTwoIntervalImage();
                    action.Invoke();
                }).AddTo(_token);
        }

        private void ResetSkillOneIntervalImage()
        {
            _timerSkillOne = 0;
            _skillOneIntervalImage.fillAmount = MinFillAmount;
        }

        private void ResetSkillTwoIntervalImage()
        {
            _timerSkillTwo = 0;
            _skillTwoIntervalImage.fillAmount = MinFillAmount;
        }

        private void SetupSkillUI(float skillOneInterval, float skillTwoInterval)
        {
            _timerSkillOne = skillOneInterval;
            _timerSkillTwo = skillTwoInterval;
            _skillOneIntervalImage.fillAmount = MaxFillAmount;
            _skillTwoIntervalImage.fillAmount = MaxFillAmount;
        }

        public void UpdateSkillUI(float skillOneInterval, float skillTwoInterval)
        {
            if (_timerSkillOne < skillOneInterval)
            {
                _timerSkillOne += Time.deltaTime;
                _skillOneIntervalImage.fillAmount = _timerSkillOne / skillOneInterval;
            }

            if (_timerSkillTwo < skillTwoInterval)
            {
                _timerSkillTwo += Time.deltaTime;
                _skillTwoIntervalImage.fillAmount = _timerSkillTwo / skillTwoInterval;
            }
        }

        private void OnDestroy()
        {
            _moveDirection.Dispose();
            _putBombSubject.Dispose();
        }
    }
}