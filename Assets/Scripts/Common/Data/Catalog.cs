using System.Collections.Generic;
using Common.Data;
using PlayFab.ClientModels;

namespace Assets.Scripts.Common.Data
{
    public class Catalog
    {
        public readonly Dictionary<int, CharacterData> Characters = new Dictionary<int, CharacterData>();
    }
}