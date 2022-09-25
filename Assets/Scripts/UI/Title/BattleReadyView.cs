using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class BattleReadyView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private List<Image> characterList;
        [SerializeField] private List<Image> backGroundList;

        public Button BackButton => backButton;

        public List<Image> CharacterList => characterList;

        public List<Image> BackGroundList => backGroundList;
    }
}