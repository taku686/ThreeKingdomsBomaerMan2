using System;
using System.Collections.Generic;
using Common.Data;

namespace Manager.DataManager
{
    public class SkillDataRepository : IDisposable
    {
        private readonly List<SkillData> skillDatum = new();

        public void AddSkillData(SkillData data)
        {
            if (skillDatum.Contains(data))
            {
                return;
            }

            skillDatum.Add(data);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}