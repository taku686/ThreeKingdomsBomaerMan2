using System;
using System.Collections.Generic;
using Common.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.MainTitle
{
    public class TitleView : MonoBehaviour
    {
        //Title_Button
        [Header("Title"), SerializeField] private Button battleButton;
        [Header("Title"), SerializeField] private Button battleModeButton;
        [Header("Title"), SerializeField] private Button characterButton;
        [Header("Title"), SerializeField] private Button shopButton;

        //CharacterList_Button
        [Header("CharacterList"), SerializeField]
        private Button backButton;


        //GameObject
        [Header("Title"), SerializeField] private GameObject lobbyGameObject;

        [Header("CharacterList"), SerializeField]
        private GameObject characterListGameObject;

        [SerializeField] private GameObject characterDetailGameObject;

        public Button BattleButton => battleButton;

        public Button BattleModeButton => battleModeButton;

        public Button CharacterButton => characterButton;

        public Button ShopButton => shopButton;

        public Button BackButton => backButton;

        public GameObject LobbyGameObject => lobbyGameObject;

        public GameObject CharacterListGameObject => characterListGameObject;

        public GameObject CharacterDetailGameObject => characterDetailGameObject;
    }
}