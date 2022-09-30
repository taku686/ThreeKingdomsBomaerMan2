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

        /*[SerializeField] private List<Image> characterList;
        [SerializeField] private List<Image> backGroundList;
        [SerializeField] private List<GameObject> gridGameObjectList;
        [SerializeField] private List<TextMeshProUGUI> textList;*/
        [SerializeField] private Transform gridParent;
        [SerializeField] private GameObject grid;

        public GameObject Grid => grid;

        public Transform GridParent => gridParent;

        public Button BackButton => backButton;
    }
}