using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterSelectView : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        [SerializeField] private GameObject horizontalGroupGameObject;

        [SerializeField] private GameObject grid;

        [SerializeField] private GameObject gridDisable;

        [SerializeField] private Transform contentsTransform;

         [SerializeField] private GemAddPopup gemAddPopup;

         public GemAddPopup GemAddPopup => gemAddPopup;

         public Button BackButton => backButton;

        public GameObject HorizontalGroupGameObject => horizontalGroupGameObject;

        public GameObject Grid => grid;

        public GameObject GridDisable => gridDisable;

        public Transform ContentsTransform => contentsTransform;
    }
}