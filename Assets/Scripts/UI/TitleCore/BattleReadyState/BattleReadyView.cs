using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class BattleReadyView : ViewBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button battleStartButton;
        [SerializeField] private Transform gridParent;
        [SerializeField] private BattleReadyGrid battleReadyGrid;

        public BattleReadyGrid _BattleReadyGrid => battleReadyGrid;
        public Transform _GridParent => gridParent;
        public Button _BackButton => backButton;
        public Button _BattleStartButton => battleStartButton;
    }
}