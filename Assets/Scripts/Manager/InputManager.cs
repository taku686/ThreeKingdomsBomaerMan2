using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Photon.Pun;
using Repository;
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
        public Button BombButton => bombButton;


        public void Initialize
        (
            PhotonView view,
            float skillOneIntervalTime,
            float skillTwoIntervalTime,
            UserData userData,
            LevelMasterDataRepository levelMasterDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            photonView = view;
            inputView = FindObjectOfType<InputView>();
            bombButton = inputView.bombButton;
            if (!photonView.IsMine)
            {
                return;
            }

            var characterId = userData.EquippedCharacterId;
            var weaponId = userData.EquippedWeapons[characterId];
            var level = userData.CharacterLevels[characterId];
            var currentLevelData = levelMasterDataRepository.GetLevelMasterData(level);
            var weaponData = weaponMasterDataRepository.GetWeaponData(weaponId);
            skillOneIntervalImage = inputView.normalSkillIntervalImage;
            skillTwoIntervalImage = inputView.specialSkillIntervalImage;
            SetupSkillUI(skillOneIntervalTime, skillTwoIntervalTime, currentLevelData, weaponData);
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

        private void SetupSkillUI
        (
            float skillOneInterval,
            float skillTwoInterval,
            LevelMasterData levelMasterData,
            WeaponMasterData weaponData
        )
        {
            inputView.skillOneButton.gameObject.SetActive(levelMasterData.IsSkillOneActive);
            inputView.skillTwoButton.gameObject.SetActive(levelMasterData.IsSkillTwoActive);
            timerSkillOne = skillOneInterval;
            timerSkillTwo = skillTwoInterval;
            skillOneIntervalImage.fillAmount = MaxFillAmount;
            skillTwoIntervalImage.fillAmount = MaxFillAmount;
            inputView.normalSkillImage.sprite = weaponData.NormalSkillMasterData.Sprite;
            inputView.specialSkillImage.sprite = weaponData.SpecialSkillMasterData.Sprite;
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