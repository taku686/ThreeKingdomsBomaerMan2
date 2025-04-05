using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FS_CombatSystem
{
    public class DeadState : State<EnemyController>
    {
        public override void Enter(EnemyController owner)
        {
            owner.VisionSensor.gameObject.SetActive(false);
            EnemyManager.i.RemoveEnemyInRange(owner);

            owner.NavAgent.enabled = false;
        }
    }
}