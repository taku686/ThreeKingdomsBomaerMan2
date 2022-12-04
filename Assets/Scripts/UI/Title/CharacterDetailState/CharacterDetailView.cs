using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterDetailView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private Button selectButton;

        public Button BackButton => backButton;

        public TextMeshProUGUI Name => name;

        public Button SelectButton => selectButton;

        public Button LeftArrowButton => leftArrowButton;

        public Button RightArrowButton => rightArrowButton;

        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
    }
}