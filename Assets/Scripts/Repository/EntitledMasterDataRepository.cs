using System;
using System.Collections.Generic;
using Data;

namespace Repository
{
    public class EntitledMasterDataRepository : IDisposable
    {
        private readonly List<EntitledMasterData> _entitledMasterDataList = new();

        public EntitledMasterData GetEntitledMasterData(int id)
        {
            return _entitledMasterDataList.Find(data => data.Id == id);
        }

        public void AddEntitledMasterData(EntitledMasterData data)
        {
            var ids = _entitledMasterDataList.ConvertAll(d => d.Id);
            if (ids.Contains(data.Id))
            {
                return; // Entitled data already exists
            }

            _entitledMasterDataList.Add(data);
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}