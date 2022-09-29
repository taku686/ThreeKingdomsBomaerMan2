using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class BattleReadyView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private List<Image> characterList;
        [SerializeField] private List<Image> backGroundList;
        [SerializeField] private List<GameObject> gridGameObjectList;
        [SerializeField] private List<TextMeshProUGUI> textList;

        public List<TextMeshProUGUI> TextList => textList;

        public List<GameObject> GridGameObjectList => gridGameObjectList;

        public Button BackButton => backButton;

        public List<Image> CharacterList => characterList;

        public List<Image> BackGroundList => backGroundList;
    }
}