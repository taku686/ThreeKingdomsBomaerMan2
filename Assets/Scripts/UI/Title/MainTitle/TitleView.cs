using System;
using Common.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.MainTitle
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private Button _battleButton;
        [SerializeField] private Button _battleModeButton;
        [SerializeField] private Button _characterButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private GameObject _lobbyGameObject;
        [SerializeField] private GameObject _characterListGameObject;
        [SerializeField] private GameObject _characterDetailGameObject;
        
        public Button BattleButton => _battleButton;

        public Button BattleModeButton => _battleModeButton;

        public Button CharacterButton => _characterButton;

        public Button ShopButton => _shopButton;

        public GameObject LobbyGameObject => _lobbyGameObject;

        public GameObject CharacterListGameObject => _characterListGameObject;

        public GameObject CharacterDetailGameObject => _characterDetailGameObject;

    }
}