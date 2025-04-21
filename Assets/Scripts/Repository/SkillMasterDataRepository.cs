using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UnityEngine;

namespace Manager.DataManager
{
    public class SkillMasterDataRepository : IDisposable
    {
        private readonly List<SkillMasterData> _skillDatum = new();

        public void AddSkillData(SkillMasterData masterData)
        {
            if (_skillDatum.Contains(masterData))
            {
                return;
            }

            _skillDatum.Add(masterData);
        }

        public SkillMasterData GetSkillData(int id)
        {
            return _skillDatum.FirstOrDefault(data => data.Id == id);
        }

        public SkillMasterData[] GetSkillDatum(int[] ids)
        {
            var skillMasterData = new SkillMasterData[ids.Length];

            for (var i = 0; i < ids.Length; i++)
            {
                skillMasterData[i] = GetSkillData(ids[i]);
            }

            return skillMasterData;
        }

        public static (StatusType, float) GetStatusSkillValue(SkillMasterData skillMasterData)
        {
            if (skillMasterData == null)
            {
                return (StatusType.None, GameCommonData.InvalidNumber);
            }

            if (!Mathf.Approximately(skillMasterData.HpPlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.Hp, skillMasterData.HpPlu);
            }

            if (!Mathf.Approximately(skillMasterData.AttackPlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.Attack, skillMasterData.AttackPlu);
            }

            if (!Mathf.Approximately(skillMasterData.DefensePlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.Defense, skillMasterData.DefensePlu);
            }

            if (!Mathf.Approximately(skillMasterData.SpeedPlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.Speed, skillMasterData.SpeedPlu);
            }

            if (!Mathf.Approximately(skillMasterData.ResistancePlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.Resistance, skillMasterData.ResistancePlu);
            }

            if (!Mathf.Approximately(skillMasterData.BombPlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.BombLimit, skillMasterData.BombPlu);
            }

            if (!Mathf.Approximately(skillMasterData.FirePlu, GameCommonData.InvalidNumber))
            {
                return (StatusType.FireRange, skillMasterData.FirePlu);
            }

            return (StatusType.None, GameCommonData.InvalidNumber);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}