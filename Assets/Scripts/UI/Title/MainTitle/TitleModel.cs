using System.Collections.Generic;
using Common.Data;
using Manager.ResourceManager;
using UnityEngine;
using Zenject;

namespace UI.Title.MainTitle
{
    
    public class TitleModel
    {
        [Inject] private ILoadResource _resourceManager;
        
        private List<Dictionary<CharacterName, CharacterData>> _characterDataList =
            new List<Dictionary<CharacterName, CharacterData>>();
        public void Initialize()
        {
            
        }

        private void InitializeCharacterData()
        {
            
        }
    }
}