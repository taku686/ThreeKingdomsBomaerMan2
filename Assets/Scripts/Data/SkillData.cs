using System;
using UnityEngine;

namespace Common.Data
{
    public class SkillData : IDisposable
    {
        public int ID;
        public string Explanation;
        public string Name;

        public void Dispose()
        {
        }
    }
}