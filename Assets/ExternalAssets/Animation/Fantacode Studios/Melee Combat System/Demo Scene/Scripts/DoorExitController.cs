using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS_CombatSystem
{
    public class DoorExitController : MonoBehaviour
    {
        public DoorController enterPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                enterPoint.enter = false;
                enterPoint.ExitFromRoom();
            }
        }
    }
}