using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Data;
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
        private const string EntitledMasterKey = "EntitledMaster";
        private const string BombMasterKey = "BombMaster";
        private const string AbnormalConditionMasterKey = "AbnormalConditionMaster";
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private LevelMasterDataRepository _levelMasterDataRepository;
        [Inject] private MissionMasterDataRepository _missionMasterDataRepository;
        [Inject] private SkillMasterDataRepository _skillMasterDataRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private EntitledMasterDataRepository _entitledMasterDataRepository;
        [Inject] private AbnormalConditionMasterDataRepository _abnormalConditionMasterDataRepository;
        private CancellationTokenSource _cts;

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
        }

        public async UniTask SetTitleData(Dictionary<string, string> titleDatum)
        {
            var characterDatum = JsonConvert.DeserializeObject<CharacterData[]>(titleDatum[CharacterMasterKey]);
            var characterLevelDatum = JsonConvert.DeserializeObject<LevelMasterData[]>(titleDatum[CharacterLevelMasterKey]);
            var missionDatum = JsonConvert.DeserializeObject<MissionMasterData[]>(titleDatum[MissionMasterKey]);
            var skillDatum = JsonConvert.DeserializeObject<SkillMasterData[]>(titleDatum[SkillMasterKey]);
            var weaponDatum = JsonConvert.DeserializeObject<WeaponMasterData[]>(titleDatum[WeaponMasterKey]);
            var entitledDatum = JsonConvert.DeserializeObject<EntitledMasterData[]>(titleDatum[EntitledMasterKey]);
            var abnormalConditionDatum = JsonConvert.DeserializeObject<AbnormalConditionMasterData[]>(titleDatum[AbnormalConditionMasterKey]);

            await SetCharacterData(characterDatum);
            SetCharacterLevelData(characterLevelDatum);
            SetMissionData(missionDatum);
            await SetSkillData(skillDatum);
            await SetWeaponData(weaponDatum);
            SetEntitledData(entitledDatum);
            SetAbnormalConditionData(abnormalConditionDatum);
        }

        private async UniTask SetCharacterData(CharacterData[] characterDatum)
        {
            foreach (var characterData in characterDatum)
            {
                characterData.CharacterObject = await LoadGameObject(GameCommonData.CharacterPrefabPath, characterData.CharaObj, _cts.Token);
                characterData.SelfPortraitSprite = await LoadCharacterSprite(characterData.Id, _cts.Token);
                characterData.ColorSprite = await LoadCharacterColor(characterData.CharaColor, _cts.Token);
                characterData.BombLimit /= FixedValue;
                characterData.FireRange /= FixedValue;
                _characterMasterDataRepository.SetCharacterData(characterData);
            }
        }

        private async UniTask SetSkillData(SkillMasterData[] skillDatum)
        {
            foreach (var skillData in skillDatum)
            {
                var id = skillData.Id;
                var explanation = skillData.Explanation;
                var name = skillData.Name;
                var sprite = await LoadSkillSprite(skillData.IconID, _cts.Token);
                var skillActionType = TranslateStringToSkillActionType(skillData._SkillActionType);
                var skillType = (SkillType)skillData.SkillTypeInt;
                var hpPlu = skillData.HpPlu;
                var attackPlu = skillData.AttackPlu;
                var defensePlu = skillData.DefensePlu;
                var speedPlu = skillData.SpeedPlu;
                var resistancePlu = skillData.ResistancePlu;
                var bombPlu = skillData.BombPlu;
                var firePlu = skillData.FirePlu;
                var coinPlu = skillData.CoinPlu;
                var gemPlu = skillData.GemPlu;
                var skillPlu = skillData.SkillPlu;
                var damagePlu = skillData.DamagePlu;
                var hpMul = skillData.HpMul;
                var attackMul = skillData.AttackMul;
                var defenseMul = skillData.DefenseMul;
                var speedMul = skillData.SpeedMul;
                var resistanceMul = skillData.ResistanceMul;
                var bombMul = skillData.BombMul;
                var fireMul = skillData.FireMul;
                var coinMul = skillData.CoinMul;
                var gemMul = skillData.GemMul;
                var skillMul = skillData.SkillMul;
                var damageMul = skillData.DamageMul;
                var numberRequirements = TranslateStringToFloatArray(skillData.NumberRequirement);
                var numberRequirementType = TranslateStringToNumberRequirementType(skillData.NumberRequirementType);
                var boolRequirementType = TranslateStringToBoolRequirementType(skillData._BoolRequirementType);
                var skillDirection = TranslateStringToSkillDirection(skillData.SkillDirection);
                var invalidAbnormalCondition = TranslateStringToAbnormalConditions(skillData.InvalidAbnormalCondition);
                var abnormalCondition = TranslateStringToAbnormalConditions(skillData.AbnormalCondition);
                var bombType = TranslateStringToBombType(skillData.BombType);
                var isAll = skillData.IsAll;
                var range = skillData.Range;
                var interval = skillData.Interval;
                var effectTime = skillData.EffectTime;
                var newSkillData = new SkillMasterData
                (
                    id,
                    explanation,
                    name,
                    sprite,
                    skillActionType,
                    skillType,
                    hpPlu,
                    attackPlu,
                    defensePlu,
                    speedPlu,
                    resistancePlu,
                    bombPlu,
                    firePlu,
                    coinPlu,
                    gemPlu,
                    skillPlu,
                    damagePlu,
                    hpMul,
                    attackMul,
                    defenseMul,
                    speedMul,
                    resistanceMul,
                    bombMul,
                    fireMul,
                    coinMul,
                    gemMul,
                    skillMul,
                    damageMul,
                    numberRequirements,
                    numberRequirementType,
                    boolRequirementType,
                    skillDirection,
                    invalidAbnormalCondition,
                    abnormalCondition,
                    bombType,
                    isAll,
                    range,
                    interval,
                    effectTime
                );

                _skillMasterDataRepository.AddSkillData(newSkillData);
            }
        }

        private async UniTask SetWeaponData(WeaponMasterData[] weaponDatum)
        {
            foreach (var weaponData in weaponDatum)
            {
                var name = weaponData.Name;
                var id = weaponData.Id;
                var weaponType = (WeaponType)weaponData.WeaponTypeInt;
                var statusSkillIds = TranslateStringToIntArray(weaponData.StatusSkillId);
                var statusSkillData = _skillMasterDataRepository.GetSkillDatum(statusSkillIds);
                var normalSkillData = _skillMasterDataRepository.GetSkillData(weaponData.NormalSkillId);
                var specialSkillData = _skillMasterDataRepository.GetSkillData(weaponData.SpecialSkillId);
                var weaponObject = await LoadWeaponGameObject(id, _cts.Token);
                var weaponIcon = await LoadWeaponSprite(id, _cts.Token);
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
                    normalSkillData,
                    statusSkillData,
                    specialSkillData,
                    scale,
                    isBothHands,
                    rare
                );

                _weaponMasterDataRepository.AddWeaponData(newWeaponData);
            }
        }

        private static int[] TranslateStringToIntArray(string statusSkillIds)
        {
            if (string.IsNullOrEmpty(statusSkillIds))
            {
                return Array.Empty<int>();
            }

            var ids = statusSkillIds.Split(',');
            var result = new int[ids.Length];
            for (var i = 0; i < ids.Length; i++)
            {
                if (int.TryParse(ids[i], out var id))
                {
                    result[i] = id;
                }
            }

            return result;
        }

        private static float[] TranslateStringToFloatArray(string statusSkillIds)
        {
            if (string.IsNullOrEmpty(statusSkillIds))
            {
                return Array.Empty<float>();
            }

            var ids = statusSkillIds.Split(',');
            var result = new float[ids.Length];
            for (var i = 0; i < ids.Length; i++)
            {
                if (float.TryParse(ids[i], out var id))
                {
                    result[i] = id;
                }
            }

            return result;
        }

        private static NumberRequirementType TranslateStringToNumberRequirementType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return NumberRequirementType.None;
            }

            return Enum.TryParse<NumberRequirementType>(value, out var result) ? result : NumberRequirementType.None;
        }

        private static BoolRequirementType TranslateStringToBoolRequirementType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BoolRequirementType.None;
            }

            return Enum.TryParse<BoolRequirementType>(value, out var result) ? result : BoolRequirementType.None;
        }

        private static SkillDirection TranslateStringToSkillDirection(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return SkillDirection.None;
            }

            return Enum.TryParse<SkillDirection>(value, out var result) ? result : SkillDirection.None;
        }

        private static BombType TranslateStringToBombType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BombType.None;
            }

            return Enum.TryParse<BombType>(value, out var result) ? result : BombType.None;
        }

        private static SkillActionType TranslateStringToSkillActionType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return SkillActionType.None;
            }

            return Enum.TryParse<SkillActionType>(value, out var result) ? result : SkillActionType.None;
        }

        private static AbnormalCondition[] TranslateStringToAbnormalConditions(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Array.Empty<AbnormalCondition>();
            }

            var ids = value.Split(',');
            var result = new AbnormalCondition[ids.Length];
            for (var i = 0; i < ids.Length; i++)
            {
                result[i] = Enum.TryParse<AbnormalCondition>(ids[i], out var abnormal) ? abnormal : AbnormalCondition.None;
            }

            return result;
        }

        private void SetCharacterLevelData(LevelMasterData[] characterLevelMasterDatum)
        {
            foreach (var characterLevelMasterData in characterLevelMasterDatum)
            {
                _levelMasterDataRepository.SetCharacterLevelData(characterLevelMasterData);
            }
        }

        private void SetEntitledData(EntitledMasterData[] entitledMasterDatum)
        {
            foreach (var entitledMasterData in entitledMasterDatum)
            {
                _entitledMasterDataRepository.AddEntitledMasterData(entitledMasterData);
            }
        }

        private void SetMissionData(MissionMasterData[] missionDatum)
        {
            foreach (var missionData in missionDatum)
            {
                _missionMasterDataRepository.AddMissionData(missionData);
            }
        }

        private void SetAbnormalConditionData(AbnormalConditionMasterData[] conditionMasterDatum)
        {
            foreach (var missionData in conditionMasterDatum)
            {
                _abnormalConditionMasterDataRepository.AddAbnormalConditionMasterData(missionData);
            }
        }

        private async UniTask<GameObject> LoadGameObject(string path, string charaObj, CancellationToken token)
        {
            if (string.IsNullOrEmpty(charaObj))
            {
                Debug.LogError("charaObj is null or empty.");
                return null;
            }

            var resource = await Resources.LoadAsync<GameObject>(path + charaObj).WithCancellation(token);
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
            if (skillId == GameCommonData.InvalidNumber)
            {
                return null;
            }

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
            _cts.Cancel();
            _cts?.Dispose();
        }
    }
}