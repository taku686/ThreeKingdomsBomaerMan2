using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterDetailView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [FormerlySerializedAs("name")] [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Button selectButton;

        public Button BackButton => backButton;

        public TextMeshProUGUI NameText => nameText;

        public Button SelectButton => selectButton;

        public Button LeftArrowButton => leftArrowButton;

        public Button RightArrowButton => rightArrowButton;

        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
    }
}