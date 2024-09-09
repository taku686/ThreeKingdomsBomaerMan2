using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Newtonsoft.Json;
using Repository;
using UnityEngine;
using Zenject;

namespace Manager.PlayFabManager
{
    public class PlayFabTitleDataManager : IDisposable
    {
        private const int FixedValue = 10;
        private const string CharacterMasterKey = "CharacterMaster";
        private const string CharacterLevelMasterKey = "CharacterLevelMaster";
        private const string MissionMasterKey = "MissionMaster";
        private const string SkillMasterKey = "SkillMaster";
        private const string WeaponMasterKey = "WeaponMaster";
        [Inject] private CharacterMasterDataRepository characterMasterDataRepository;
        [Inject] private LevelMasterDataRepository levelMasterDataRepository;
        [Inject] private MissionDataRepository missionDataRepository;
        [Inject] private SkillDataRepository skillDataRepository;
        [Inject] private WeaponMasterDataRepository weaponMasterDataRepository;
        private CancellationTokenSource cts;

        public void Initialize()
        {
            cts = new CancellationTokenSource();
        }

        public async UniTask SetTitleData(Dictionary<string, string> titleDatum)
        {
            var characterDatum =
                JsonConvert.DeserializeObject<CharacterData[]>(titleDatum[CharacterMasterKey]);
            var characterLevelDatum =
                JsonConvert.DeserializeObject<LevelMasterData[]>(titleDatum[CharacterLevelMasterKey]);
            var missionDatum =
                JsonConvert.DeserializeObject<MissionData[]>(titleDatum[MissionMasterKey]);
            var skillDatum =
                JsonConvert.DeserializeObject<SkillMasterData[]>(titleDatum[SkillMasterKey]);
            var weaponDatum =
                JsonConvert.DeserializeObject<WeaponMasterData[]>(titleDatum[WeaponMasterKey]);
            await SetCharacterData(characterDatum);
            SetCharacterLevelData(characterLevelDatum);
            SetMissionData(missionDatum);
            await SetSkillData(skillDatum);
            await SetWeaponData(weaponDatum);
        }

        private async UniTask SetCharacterData(CharacterData[] characterDatum)
        {
            foreach (var characterData in characterDatum)
            {
                characterData.CharacterObject =
                    await LoadGameObject(GameCommonData.CharacterPrefabPath, characterData.CharaObj, cts.Token);
                characterData.SelfPortraitSprite =
                    await LoadCharacterSprite(characterData.Id, cts.Token);
                characterData.ColorSprite =
                    await LoadCharacterColor(characterData.CharaColor, cts.Token);
                characterData.BombLimit /= FixedValue;
                characterData.FireRange /= FixedValue;
                characterMasterDataRepository.SetCharacterData(characterData);
            }
        }

        private async UniTask SetSkillData(SkillMasterData[] skillDatum)
        {
            foreach (var skillData in skillDatum)
            {
                var id = skillData.Id;
                var explanation = skillData.Explanation;
                var name = skillData.Name;
                var sprite = await LoadSkillSprite(skillData.IconID, cts.Token);
                var skillType = (SkillType)skillData.SkillTypeInt;
                var attributeType = (AttributeType)skillData.AttributeTypeInt;
                var skillEffectType =
                    (SkillEffectType)Enum.Parse(typeof(SkillEffectType), skillData.SkillEffectTypeString);
                var amount = skillData.Amount;
                var newSkillData = new SkillMasterData
                (
                    id,
                    explanation,
                    name,
                    sprite,
                    skillType,
                    null,
                    attributeType,
                    skillEffectType,
                    amount
                );

                skillDataRepository.AddSkillData(newSkillData);
            }
        }

        private async UniTask SetWeaponData(WeaponMasterData[] weaponDatum)
        {
            foreach (var weaponData in weaponDatum)
            {
                var name = weaponData.Name;
                var id = weaponData.Id;
                var weaponType = (WeaponType)weaponData.WeaponTypeInt;
                var attributeType = (AttributeType)weaponData.AttributeTypeInt;
                var weaponObject = await LoadWeaponGameObject(id, cts.Token);
                var weaponIcon = await LoadWeaponSprite(id, cts.Token);
                var statusSkillData = skillDataRepository.GetSkillData(weaponData.StatusSkillId);
                var normalSkillData = skillDataRepository.GetSkillData(weaponData.NormalSkillId);
                var specialSkillData = skillDataRepository.GetSkillData(weaponData.SpecialSkillId);
                var scale = weaponData.Scale;
                var isBothHands = weaponData.IsBothHands;
                var rare = weaponData.Rare;
                var newWeaponData = new WeaponMasterData
                (
                    name,
                    id,
                    weaponObject,
                    weaponEffectObj: null,
                    weaponIcon,
                    weaponType,
                    attributeType,
                    normalSkillData,
                    statusSkillData,
                    specialSkillData,
                    scale,
                    isBothHands,
                    rare
                );

                weaponMasterDataRepository.AddWeaponData(newWeaponData);
            }
        }

        private void SetCharacterLevelData(LevelMasterData[] characterLevelMasterDatum)
        {
            foreach (var characterLevelMasterData in characterLevelMasterDatum)
            {
                levelMasterDataRepository.SetCharacterLevelData(characterLevelMasterData);
            }
        }

        private void SetMissionData(MissionData[] missionDatum)
        {
            foreach (var missionData in missionDatum)
            {
                missionDataRepository.AddMissionData(missionData);
            }
        }

        private async UniTask<GameObject> LoadGameObject(string path, string charaObj, CancellationToken token)
        {
            if (string.IsNullOrEmpty(charaObj))
            {
                Debug.LogError("charaObj is null or empty.");
                return null;
            }

            var resource = await Resources.LoadAsync<GameObject>(path + charaObj)
                .WithCancellation(token);
            return (GameObject)resource;
        }

        private async UniTask<GameObject> LoadWeaponGameObject(int weaponId, CancellationToken token)
        {
            var response = await Resources
                .LoadAsync<GameObject>(GameCommonData.WeaponPrefabPath + weaponId)
                .WithCancellation(token);
            return (GameObject)response;
        }

        private async UniTask<Sprite> LoadCharacterSprite(int id, CancellationToken token)
        {
            var response = await Resources.LoadAsync<Sprite>(GameCommonData.CharacterSpritePath + id)
                .WithCancellation(token);
            return (Sprite)response;
        }

        private async UniTask<Sprite> LoadSkillSprite(int characterId, int skillId, CancellationToken token)
        {
            var response = await Resources
                .LoadAsync<Sprite>(GameCommonData.SkillSpritePath + characterId + "_" + skillId)
                .WithCancellation(token);
            return (Sprite)response;
        }

        private async UniTask<Sprite> LoadSkillSprite(int skillId, CancellationToken token)
        {
            var response = await Resources
                .LoadAsync<Sprite>(GameCommonData.SkillSpritePath + skillId)
                .WithCancellation(token);
            return (Sprite)response;
        }

        private async UniTask<Sprite> LoadWeaponSprite(int weaponId, CancellationToken token)
        {
            var response = await Resources
                .LoadAsync<Sprite>(GameCommonData.WeaponSpritePath + weaponId)
                .WithCancellation(token);
            return (Sprite)response;
        }

        private async UniTask<Sprite> LoadCharacterColor(string charaColor, CancellationToken token)
        {
            var colorIndex = (int)GameCommonData.GetCharacterColor(charaColor);
            var resource = await Resources.LoadAsync<Sprite>(GameCommonData.CharacterColorPath + colorIndex)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        private async UniTask<GameObject> LoadWeaponEffect(int weaponEffectId, CancellationToken token)
        {
            var resource = await Resources.LoadAsync<GameObject>(GameCommonData.WeaponEffectPrefabPath + weaponEffectId)
                .WithCancellation(token);
            return (GameObject)resource;
        }

        public void Dispose()
        {
            cts.Cancel();
            cts?.Dispose();
        }
    }
}