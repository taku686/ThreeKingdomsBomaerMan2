using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class BattleReadyView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        
        [SerializeField] private Button battleStartButton;
        [SerializeField] private Transform gridParent;
        [SerializeField] private GameObject grid;

        public GameObject Grid => grid;
        public Transform GridParent => gridParent;
        public Button BackButton => backButton;
        public Button BattleStartButton => battleStartButton;
    }
}