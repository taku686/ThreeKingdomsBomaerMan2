using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class BattleReady : ViewBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button battleStartButton;
        [SerializeField] private Transform gridParent;
        [SerializeField] private BattleReadyGrid battleReadyGrid;

        public BattleReadyGrid BattleReadyGrid => battleReadyGrid;
        public Transform GridParent => gridParent;
        public Button BackButton => backButton;
        public Button BattleStartButton => battleStartButton;
    }
}