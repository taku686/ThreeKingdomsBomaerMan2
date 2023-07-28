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
        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;
        private PhotonView _photonView;
        private CancellationToken _token;
        private Button _bombButton;
        private Image _skillOneIntervalImage;
        private Image _skillTwoIntervalImage;
        private float _timerSkillOne;
        private float _timerSkillTwo;
        private CharacterData _characterData;
        public Button BombButton => _bombButton;


        public void Initialize(PhotonView photonView, float skillOneIntervalTime, float skillTwoIntervalTime,
            CharacterData characterData, UserDataManager userDataManager)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _photonView = photonView;
            _inputView = FindObjectOfType<InputView>();
            _bombButton = _inputView.bombButton;
            if (!_photonView.IsMine)
            {
                return;
            }

            var currentLevelData = userDataManager.GetCurrentLevelData(characterData.Id);
            _skillOneIntervalImage = _inputView.skillOneIntervalImage;
            _skillTwoIntervalImage = _inputView.skillTwoIntervalImage;
            _characterData = characterData;
            SetupSkillUI(skillOneIntervalTime, skillTwoIntervalTime, currentLevelData);
        }

        public void SetOnClickSkillOne(float intervalTime, Action action, CancellationToken token)
        {
            _inputView.skillOneButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime)).Subscribe(
                _ =>
                {
                    ResetSkillOneIntervalImage();
                    action.Invoke();
                }).AddTo(token);
        }

        public void SetOnClickSkillTwo(float intervalTime, Action action, CancellationToken token)
        {
            _inputView.skillTwoButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime))
                .Subscribe(_ =>
                {
                    ResetSkillTwoIntervalImage();
                    action.Invoke();
                }).AddTo(token);
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

        private void SetupSkillUI(float skillOneInterval, float skillTwoInterval, CharacterLevelData levelData)
        {
            _inputView.skillOneButton.gameObject.SetActive(levelData.IsSkillOneActive);
            _inputView.skillTwoButton.gameObject.SetActive(levelData.IsSkillTwoActive);
            _timerSkillOne = skillOneInterval;
            _timerSkillTwo = skillTwoInterval;
            _skillOneIntervalImage.fillAmount = MaxFillAmount;
            _skillTwoIntervalImage.fillAmount = MaxFillAmount;
            _inputView.skillOneImage.sprite = _characterData.SkillOneSprite;
            _inputView.skillTwoImage.sprite = _characterData.SkillTwoSprite;
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
        }
    }
}