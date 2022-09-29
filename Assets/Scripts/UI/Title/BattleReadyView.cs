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
        [SerializeField] private List<GameObject> gridGameObjectList;

        public List<GameObject> GridGameObjectList => gridGameObjectList;

        public Button BackButton => backButton;

        public List<Image> CharacterList => characterList;

        public List<Image> BackGroundList => backGroundList;
    }
}