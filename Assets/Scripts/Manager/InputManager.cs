using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Photon.Pun;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputView _inputView;
        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;
        private PhotonView _photonView;
        private Image _normalSkillIntervalImage;
        private Image _specialSkillIntervalImage;
        private Image _dashIntervalImage;
        private float _timerNormalSkill;
        private float _timerSpecialSkill;
        private float _timerDashSkill;
        private float _normalSkillInterval;
        private float _specialSkillInterval;
        private float _dashInterval;
        public Button BombButton { get; private set; }


        public void Initialize(PhotonView view, PhotonNetworkManager photonNetworkManager)
        {
            _photonView = view;
            _inputView = FindObjectOfType<InputView>();
            BombButton = _inputView.bombButton;
            if (!_photonView.IsMine)
            {
                return;
            }

            var actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            var weaponData = photonNetworkManager.GetWeaponData(actorNumber);
            var currentLevelData = photonNetworkManager.GetLevelMasterData(actorNumber);
            _normalSkillIntervalImage = _inputView.normalSkillIntervalImage;
            _specialSkillIntervalImage = _inputView.specialSkillIntervalImage;
            _dashIntervalImage = _inputView._dashIntervalImage;
            SetupSkillUI(currentLevelData, weaponData);
        }

        public void OnClickNormalSkill(Action action, CancellationToken token)
        {
            _inputView.normalSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_normalSkillInterval))
                .Subscribe(_ =>
                {
                    ResetSkillOneIntervalImage();
                    action.Invoke();
                })
                .AddTo(token);
        }

        public void OnClickSpecialSkill(Action action, CancellationToken token)
        {
            _inputView.specialSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_specialSkillInterval))
                .Subscribe(_ =>
                {
                    ResetSkillTwoIntervalImage();
                    action.Invoke();
                })
                .AddTo(token);
        }

        public void OnClickDash(Action action, CancellationToken token)
        {
            _inputView._dashButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_dashInterval))
                .Subscribe(_ =>
                {
                    ResetDashIntervalImage();
                    action.Invoke();
                })
                .AddTo(token);
        }

        private void ResetSkillOneIntervalImage()
        {
            _timerNormalSkill = 0;
            _normalSkillIntervalImage.fillAmount = MinFillAmount;
        }

        private void ResetSkillTwoIntervalImage()
        {
            _timerSpecialSkill = 0;
            _specialSkillIntervalImage.fillAmount = MinFillAmount;
        }

        private void ResetDashIntervalImage()
        {
            _timerDashSkill = 0;
            _dashIntervalImage.fillAmount = MinFillAmount;
        }

        private void SetupSkillUI
        (
            LevelMasterData levelMasterData,
            WeaponMasterData weaponData
        )
        {
            var normalSkill = weaponData.NormalSkillMasterData;
            var specialSkill = weaponData.SpecialSkillMasterData;
            var isActiveNormalButton = levelMasterData.IsSkillOneActive && normalSkill.SkillTypeInt == (int)SkillType.Active;
            var isActiveSpecialButton = levelMasterData.IsSkillTwoActive && specialSkill.SkillTypeInt == (int)SkillType.Active;
            _inputView.normalSkillButton.gameObject.SetActive(isActiveNormalButton);
            _inputView.specialSkillButton.gameObject.SetActive(isActiveSpecialButton);
            _normalSkillInterval = normalSkill.Interval;
            _specialSkillInterval = specialSkill.Interval;
            _dashInterval = GameCommonData.DashInterval;
            _timerNormalSkill = normalSkill.Interval;
            _timerSpecialSkill = specialSkill.Interval;
            _normalSkillIntervalImage.fillAmount = MaxFillAmount;
            _specialSkillIntervalImage.fillAmount = MaxFillAmount;
            _inputView.normalSkillImage.sprite = weaponData.NormalSkillMasterData.Sprite;
            _inputView.specialSkillImage.sprite = weaponData.SpecialSkillMasterData.Sprite;
        }

        public void UpdateSkillUI()
        {
            if (_timerNormalSkill < _normalSkillInterval)
            {
                _timerNormalSkill += Time.deltaTime;
                _normalSkillIntervalImage.fillAmount = _timerNormalSkill / _normalSkillInterval;
            }

            if (_timerSpecialSkill < _specialSkillInterval)
            {
                _timerSpecialSkill += Time.deltaTime;
                _specialSkillIntervalImage.fillAmount = _timerSpecialSkill / _specialSkillInterval;
            }

            if (_timerDashSkill < _dashInterval)
            {
                _timerDashSkill += Time.deltaTime;
                _dashIntervalImage.fillAmount = _timerDashSkill / _dashInterval;
            }
        }
    }
}