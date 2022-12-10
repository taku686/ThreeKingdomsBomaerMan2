using System;
using Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterGrid : MonoBehaviour
    {
        [HideInInspector] public CharacterData CharacterData;
        public Image characterImage;
        public Image backGroundImage;
        public TextMeshProUGUI nameText;
        public Button gridButton;
    }
}