using UnityEngine;

namespace UI.BattleCore
{
    public class BattleViewBase : MonoBehaviour
    {
        [SerializeField] private Manager.BattleManager.BattleCore.State _state;

        public Manager.BattleManager.BattleCore.State _State => _state;
    }
}