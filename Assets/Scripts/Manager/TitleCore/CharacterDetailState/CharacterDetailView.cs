using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterDetailView : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        [FormerlySerializedAs("name")] [SerializeField]
        private TextMeshProUGUI nameText;

        [SerializeField] private Button selectButton;
        [SerializeField] private RectTransform leftArrowRect;
        [SerializeField] private RectTransform rightArrowRect;
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
        [SerializeField] private CharacterStatusView characterStatusView;
        [SerializeField] private SkillsView skillsView;

        public SkillsView SkillsView => skillsView;
        public CharacterStatusView CharacterStatusView => characterStatusView;
        public Button BackButton => backButton;
        public TextMeshProUGUI NameText => nameText;
        public Button SelectButton => selectButton;
        public RectTransform LeftArrowRect => leftArrowRect;
        public RectTransform RightArrowRect => rightArrowRect;
        public Button LeftArrowButton => leftArrowButton;
        public Button RightArrowButton => rightArrowButton;
    }
}