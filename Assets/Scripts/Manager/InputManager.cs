using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputView inputView;
        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;
        private PhotonView photonView;
        private Button bombButton;
        private Image skillOneIntervalImage;
        private Image skillTwoIntervalImage;
        private float timerSkillOne;
        private float timerSkillTwo;
        private CharacterData characterData;
        public Button BombButton => bombButton;


        public void Initialize(PhotonView view, float skillOneIntervalTime, float skillTwoIntervalTime,
            CharacterData data, UserDataManager userDataManager)
        {
            photonView = view;
            inputView = FindObjectOfType<InputView>();
            bombButton = inputView.bombButton;
            if (!photonView.IsMine)
            {
                return;
            }

            var currentLevelData = userDataManager.GetCurrentLevelData(data.Id);
            skillOneIntervalImage = inputView.skillOneIntervalImage;
            skillTwoIntervalImage = inputView.skillTwoIntervalImage;
            characterData = data;
            SetupSkillUI(skillOneIntervalTime, skillTwoIntervalTime, currentLevelData);
        }

        public void SetOnClickSkillOne(float intervalTime, Action action, CancellationToken token)
        {
            inputView.skillOneButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime)).Subscribe(
                _ =>
                {
                    ResetSkillOneIntervalImage();
                    action.Invoke();
                }).AddTo(token);
        }

        public void SetOnClickSkillTwo(float intervalTime, Action action, CancellationToken token)
        {
            inputView.skillTwoButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(intervalTime))
                .Subscribe(_ =>
                {
                    ResetSkillTwoIntervalImage();
                    action.Invoke();
                }).AddTo(token);
        }

        private void ResetSkillOneIntervalImage()
        {
            timerSkillOne = 0;
            skillOneIntervalImage.fillAmount = MinFillAmount;
        }

        private void ResetSkillTwoIntervalImage()
        {
            timerSkillTwo = 0;
            skillTwoIntervalImage.fillAmount = MinFillAmount;
        }

        private void SetupSkillUI(float skillOneInterval, float skillTwoInterval, CharacterLevelData levelData)
        {
            inputView.skillOneButton.gameObject.SetActive(levelData.IsSkillOneActive);
            inputView.skillTwoButton.gameObject.SetActive(levelData.IsSkillTwoActive);
            timerSkillOne = skillOneInterval;
            timerSkillTwo = skillTwoInterval;
            skillOneIntervalImage.fillAmount = MaxFillAmount;
            skillTwoIntervalImage.fillAmount = MaxFillAmount;
            inputView.skillOneImage.sprite = characterData.SkillOneSprite;
            inputView.skillTwoImage.sprite = characterData.SkillTwoSprite;
        }

        public void UpdateSkillUI(float skillOneInterval, float skillTwoInterval)
        {
            if (timerSkillOne < skillOneInterval)
            {
                timerSkillOne += Time.deltaTime;
                skillOneIntervalImage.fillAmount = timerSkillOne / skillOneInterval;
            }

            if (timerSkillTwo < skillTwoInterval)
            {
                timerSkillTwo += Time.deltaTime;
                skillTwoIntervalImage.fillAmount = timerSkillTwo / skillTwoInterval;
            }
        }
    }
}