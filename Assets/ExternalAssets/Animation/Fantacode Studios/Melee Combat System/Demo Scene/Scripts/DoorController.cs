using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FS_CombatSystem 
{

    public class DoorController : MonoBehaviour
    {
        public GameObject spawnObject;
        public WeaponData weaponData;
        DemoSceneDoorManager doorManager;
        [HideInInspector] public bool enter;
        public List<GameObject> adjacentDoors = new List<GameObject>();

        private void Awake()
        {
            doorManager = FindObjectOfType<DemoSceneDoorManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var alreadyEntered = enter;
                enter = true;
                if (!alreadyEntered)
                {
                    doorManager.SetRoomForTutorial(weaponData, spawnObject);
                    HandleDoorState();
                }
            }
        }

        void HandleDoorState()
        {
            foreach (var door in adjacentDoors)
            {
                door.GetComponent<MeshRenderer>().material = enter ? doorManager.closedDoorMat : doorManager.openedDoorMat;
                door.GetComponent<MeshCollider>().enabled = enter;
            }
        }

        public void ExitFromRoom()
        {
            doorManager.SetRoomForTutorial(doorManager.defaultWeapon, null);
            HandleDoorState();
        }
    } 
}
