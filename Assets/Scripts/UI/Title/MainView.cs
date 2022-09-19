using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject mainGameObject;

        [SerializeField] private GameObject characterListGameObject;

        [SerializeField] private GameObject characterDetailGameObject;
        [SerializeField] private Button characterSelectButton;

        public Button CharacterSelectButton => characterSelectButton;

        public GameObject MainGameObject => mainGameObject;

        public GameObject CharacterListGameObject => characterListGameObject;

        public GameObject CharacterDetailGameObject => characterDetailGameObject;
    }
}