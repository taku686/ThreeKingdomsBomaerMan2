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
        private Image normalSkillIntervalImage;
        private Image specialSkillIntervalImage;
        private float timerNormalSkill;
        private float timerSpecialSkill;
        private float normalSkillInterval;
        private float specialSkillInterval;
        public Button BombButton => bombButton;


        public void Initialize
        (
            PhotonView view,
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
            normalSkillIntervalImage = inputView.normalSkillIntervalImage;
            specialSkillIntervalImage = inputView.specialSkillIntervalImage;
            SetupSkillUI(currentLevelData, weaponData);
        }

        public void OnClickNormalSkill(Action action, CancellationToken token)
        {
            inputView.normalSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(normalSkillInterval))
                .Subscribe(_ =>
                {
                    ResetSkillOneIntervalImage();
                    action.Invoke();
                }).AddTo(token);
        }

        public void OnClickSpecialSkill(Action action, CancellationToken token)
        {
            inputView.specialSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(specialSkillInterval))
                .Subscribe(_ =>
                {
                    ResetSkillTwoIntervalImage();
                    action.Invoke();
                }).AddTo(token);
        }

        private void ResetSkillOneIntervalImage()
        {
            timerNormalSkill = 0;
            normalSkillIntervalImage.fillAmount = MinFillAmount;
        }

        private void ResetSkillTwoIntervalImage()
        {
            timerSpecialSkill = 0;
            specialSkillIntervalImage.fillAmount = MinFillAmount;
        }

        private void SetupSkillUI
        (
            LevelMasterData levelMasterData,
            WeaponMasterData weaponData
        )
        {
            inputView.normalSkillButton.gameObject.SetActive(levelMasterData.IsSkillOneActive);
            inputView.specialSkillButton.gameObject.SetActive(levelMasterData.IsSkillTwoActive);
            var normalSkill = weaponData.NormalSkillMasterData.Interval;
            var specialSkill = weaponData.SpecialSkillMasterData.Interval;
            normalSkillInterval = normalSkill;
            specialSkillInterval = specialSkill;
            timerNormalSkill = normalSkill;
            timerSpecialSkill = specialSkill;
            normalSkillIntervalImage.fillAmount = MaxFillAmount;
            specialSkillIntervalImage.fillAmount = MaxFillAmount;
            inputView.normalSkillImage.sprite = weaponData.NormalSkillMasterData.Sprite;
            inputView.specialSkillImage.sprite = weaponData.SpecialSkillMasterData.Sprite;
        }

        public void UpdateSkillUI()
        {
            if (timerNormalSkill < normalSkillInterval)
            {
                timerNormalSkill += Time.deltaTime;
                normalSkillIntervalImage.fillAmount = timerNormalSkill / normalSkillInterval;
            }

            if (timerSpecialSkill < specialSkillInterval)
            {
                timerSpecialSkill += Time.deltaTime;
                specialSkillIntervalImage.fillAmount = timerSpecialSkill / specialSkillInterval;
            }
        }
    }
}