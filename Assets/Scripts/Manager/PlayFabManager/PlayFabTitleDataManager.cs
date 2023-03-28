using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Manager.PlayFabManager
{
    public class PlayFabTitleDataManager : IDisposable
    {
        private const int ModifiedValue = 10;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        private CancellationTokenSource _cancellationTokenSource;

        public void Initialize()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async UniTask SetTitleData(Dictionary<string, string> titleDatum)
        {
            var characterDatum =
                JsonConvert.DeserializeObject<CharacterData[]>
                    (titleDatum[GameCommonData.CharacterMasterKey]);
            await SetCharacterData(characterDatum);
            var characterLevelDatum =
                JsonConvert.DeserializeObject<CharacterLevelData[]>
                    (titleDatum[GameCommonData.CharacterLevelMasterKey]);
            SetCharacterLevelData(characterLevelDatum);
        }

        private async UniTask SetCharacterData(CharacterData[] characterDatum)
        {
            foreach (var characterData in characterDatum)
            {
                characterData.CharacterObject = await LoadGameObject(GameCommonData.CharacterPrefabPath,
                    characterData.CharaObj, _cancellationTokenSource.Token);
                characterData.SelfPortraitSprite =
                    await LoadCharacterSprite(characterData.ID, _cancellationTokenSource.Token);
                characterData.ColorSprite =
                    await LoadCharacterColor(characterData.CharaColor, _cancellationTokenSource.Token);
                characterData.SkillOneSprite =
                    await LoadSkillSprite(characterData.ID, characterData.SkillOneId, _cancellationTokenSource.Token);
                characterData.SkillTwoSprite =
                    await LoadSkillSprite(characterData.ID, characterData.SkillTwoId, _cancellationTokenSource.Token);
                characterData.BombLimit /= ModifiedValue;
                characterData.FireRange /= ModifiedValue;
                _characterDataManager.SetCharacterData(characterData);
            }
        }

        private void SetCharacterLevelData(CharacterLevelData[] characterLevelMasterDatum)
        {
            foreach (var characterLevelMasterData in characterLevelMasterDatum)
            {
                Debug.Log(characterLevelMasterData.IsSkillOneActive);
                _characterLevelDataManager.SetCharacterLevelData(characterLevelMasterData);
            }
        }

        private async UniTask<GameObject> LoadGameObject(string path, string charaObj, CancellationToken token)
        {
            if (string.IsNullOrEmpty(charaObj))
            {
                return null;
            }

            var resource = await Resources.LoadAsync<GameObject>(path + charaObj)
                .WithCancellation(token);
            return (GameObject)resource;
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

        private async UniTask<Sprite> LoadCharacterColor(string charaColor, CancellationToken token)
        {
            var colorIndex = (int)GameCommonData.GetCharacterColor(charaColor);
            var resource = await Resources.LoadAsync<Sprite>(GameCommonData.CharacterColorPath + colorIndex)
                .WithCancellation(token);
            return (Sprite)resource;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}