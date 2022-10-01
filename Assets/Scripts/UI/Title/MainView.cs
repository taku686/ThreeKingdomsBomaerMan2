using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject mainGameObject;
        [SerializeField] private GameObject characterListGameObject;
        [SerializeField] private GameObject battleReadyGameObject;
        [SerializeField] private GameObject characterDetailGameObject;
        [SerializeField] private GameObject sceneTransitionGameObject;
        [SerializeField] private Button characterSelectButton;
        [SerializeField] private Button battleReadyButton;

        public Button BattleReadyButton => battleReadyButton;
        public Button CharacterSelectButton => characterSelectButton;
        public GameObject MainGameObject => mainGameObject;
        public GameObject CharacterListGameObject => characterListGameObject;
        public GameObject CharacterDetailGameObject => characterDetailGameObject;
        public GameObject BattleReadyGameObject => battleReadyGameObject;
        public GameObject SceneTransitionGameObject => sceneTransitionGameObject;
    }
}