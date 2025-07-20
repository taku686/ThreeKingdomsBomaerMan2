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
        [Inject] private ResourcesObjectRepository _resourcesObjectRepository;
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

            await SetSkillData(skillDatum);
            SetCharacterData(characterDatum);
            SetCharacterLevelData(characterLevelDatum);
            SetMissionData(missionDatum);
            await SetWeaponData(weaponDatum);
            SetEntitledData(entitledDatum);
            SetAbnormalConditionData(abnormalConditionDatum);
        }

        private void SetCharacterData(CharacterData[] characterDatum)
        {
            foreach (var characterData in characterDatum)
            {
                characterData.CharacterObject = _resourcesObjectRepository.GetCharacterPrefab(characterData.Id);
                characterData.SelfPortraitSprite = _resourcesObjectRepository.GetCharacterIcon(characterData.Id);
                characterData.ColorSprite = _resourcesObjectRepository.GetCharacterColor(GameCommonData.GetCharacterColor(characterData.CharaColor));
                characterData._PassiveSkillMasterData = _skillMasterDataRepository.GetSkillData(characterData.PassiveSkillId);
                characterData._NormalSkillMasterData = _skillMasterDataRepository.GetSkillData(characterData.NormalSkillId);
                characterData._SpecialSkillMasterData = _skillMasterDataRepository.GetSkillData(characterData.SpecialSkillId);
                characterData.BombLimit /= FixedValue;
                characterData.FireRange /= FixedValue;
                _characterMasterDataRepository.SetCharacterData(characterData);
            }
        }

        private async UniTask SetSkillData(IEnumerable<SkillMasterData> skillDatum)
        {
            foreach (var skillData in skillDatum)
            {
                var id = skillData.Id;
                var explanation = skillData.Explanation;
                var name = skillData.Name;
                //await LoadSkillIconResources(id, skillData.IconID);
                var sprite = _resourcesObjectRepository.GetSkillIcon(id);
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
                var skillDirection = TranslateStringToSkillDirection(skillData._SkillDirection);
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
                    damageMul,
                    coinMul,
                    gemMul,
                    skillMul,
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

        private async UniTask SetWeaponData(IEnumerable<WeaponMasterData> weaponDatum)
        {
            foreach (var weaponData in weaponDatum)
            {
                var name = weaponData.Name;
                var id = weaponData.Id;
                //await _resourcesObjectRepository.SetWeaponData(id);
                var weaponType = (WeaponType)weaponData.WeaponTypeInt;
                var statusSkillIds = TranslateStringToIntArray(weaponData.StatusSkillId);
                var statusSkillData = _skillMasterDataRepository.GetSkillDatum(statusSkillIds);
                var normalSkillData = _skillMasterDataRepository.GetSkillData(weaponData.NormalSkillId);
                var weaponObject = _resourcesObjectRepository.GetWeaponPrefab(id);
                var weaponIcon = _resourcesObjectRepository.GetWeaponIcon(id);
                var scale = weaponData.Scale;
                var isBothHands = weaponData.IsBothHands;
                var rare = weaponData.Rare;
                var coinMul = weaponData.CoinMul;
                var gemMul = weaponData.GemMul;
                var skillMul = weaponData.SkillMul;
                var rangeMul = weaponData.RangeMul;

                var newWeaponData = new WeaponMasterData
                (
                    name,
                    id,
                    weaponObject,
                    weaponIcon,
                    weaponType,
                    normalSkillData,
                    statusSkillData,
                    scale,
                    isBothHands,
                    rare,
                    coinMul,
                    gemMul,
                    skillMul,
                    rangeMul
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

        private void SetCharacterLevelData(IEnumerable<LevelMasterData> characterLevelMasterDatum)
        {
            foreach (var characterLevelMasterData in characterLevelMasterDatum)
            {
                _levelMasterDataRepository.SetCharacterLevelData(characterLevelMasterData);
            }
        }

        private void SetEntitledData(IEnumerable<EntitledMasterData> entitledMasterDatum)
        {
            foreach (var entitledMasterData in entitledMasterDatum)
            {
                _entitledMasterDataRepository.AddEntitledMasterData(entitledMasterData);
            }
        }

        private void SetMissionData(IEnumerable<MissionMasterData> missionDatum)
        {
            foreach (var missionData in missionDatum)
            {
                _missionMasterDataRepository.AddMissionData(missionData);
            }
        }

        private void SetAbnormalConditionData(IEnumerable<AbnormalConditionMasterData> conditionMasterDatum)
        {
            foreach (var missionData in conditionMasterDatum)
            {
                _abnormalConditionMasterDataRepository.AddAbnormalConditionMasterData(missionData);
            }
        }

        private async UniTask LoadSkillIconResources(int skillId, int iconId)
        {
            var skillIcon = await Resources.LoadAsync<Sprite>(GameCommonData.SkillIconSpritePath + iconId);
            _resourcesObjectRepository.SetSkillSprite(skillId, skillIcon as Sprite);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts?.Dispose();
        }
    }
}