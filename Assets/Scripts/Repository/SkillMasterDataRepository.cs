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

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}