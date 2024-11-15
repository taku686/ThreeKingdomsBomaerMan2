using System;
using System.Collections.Generic;
using Common.Data;

namespace Manager.DataManager
{
    public class SkillMasterDataRepository : IDisposable
    {
        private readonly List<SkillMasterData> skillDatum = new();

        public void AddSkillData(SkillMasterData masterData)
        {
            if (skillDatum.Contains(masterData))
            {
                return;
            }

            skillDatum.Add(masterData);
        }

        public SkillMasterData GetSkillData(int id)
        {
            return skillDatum.Find(data => data.Id == id);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}