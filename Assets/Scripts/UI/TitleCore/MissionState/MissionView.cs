using Common.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class MissionView : ViewBase
    {
        public MissionGrid missionGrid;
        public Transform gridParent;
        public Button backButton;

        private const string CanGet = "Get";
        private const string InProgress = "In Progress";
        private const string ProgressBarText = " <#b3bedb>/ ";

        public MissionGrid GenerateGrid
        (
            UserData.MissionData missionData,
            MissionMasterData masterData,
            CharacterData characterMasterData,
            WeaponMasterData weaponMasterData,
            Sprite missionSprite,
            Sprite rewardSprite
        )
        {
            var actionCount = masterData.ActionCount;
            var grid = Instantiate(missionGrid, gridParent);
            var progress = missionData._progress;
            progress = progress >= actionCount ? actionCount : progress;

            grid.missionImage.sprite = missionSprite;
            grid.rewardImage.sprite = rewardSprite;
            grid.progressSlider.maxValue = actionCount;
            grid.progressSlider.value = progress;
            grid.progressText.text = progress + ProgressBarText + actionCount;
            grid.missionText.text = GetExplanationText(masterData, characterMasterData, weaponMasterData);
            grid.buttonText.text = progress >= actionCount ? CanGet : InProgress;
            grid.getButton.enabled = progress >= actionCount;

            grid.rewardText.text = masterData.RewardAmount.ToString("D");

            return grid;
        }

        private string GetExplanationText
        (
            MissionMasterData masterData,
            CharacterData characterMasterData,
            WeaponMasterData weaponMasterData
        )
        {
            var actionCount = masterData.ActionCount;
            var actionId = masterData.Action;
            var explanation = masterData.Explanation.Replace("n", actionCount.ToString());
            if (GameCommonData.IsMissionsUsingCharacter(actionId))
            {
                var characterName = characterMasterData.Name;
                explanation = explanation.Replace("x", characterName);
            }

            if (GameCommonData.IsMissionsUsingWeapon(actionId))
            {
                var weaponName = weaponMasterData.Name;
                explanation = explanation.Replace("x", weaponName);
            }

            return explanation;
        }
    }
}