using FS_CombatSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace FS_CombatSystem
{
    public class DemoSceneDoorManager : MonoBehaviour
    {
        GameObject currentObjectInTheRoom;
        public WeaponData defaultWeapon;
        public MeleeFighter player;
        public Material openedDoorMat;
        public Material closedDoorMat;

        private void Awake()
        {
            player.gameObject.layer = LayerMask.NameToLayer("Player");
        }


        public void SetRoomForTutorial(WeaponData weaponData, GameObject _object)
        {
            if (currentObjectInTheRoom != null)
                Destroy(currentObjectInTheRoom);

            if (_object != null)
            {
                currentObjectInTheRoom = Instantiate(_object);
                var enemies = currentObjectInTheRoom.GetComponentsInChildren<EnemyController>().ToList();
                var visionsensors = currentObjectInTheRoom.GetComponentsInChildren<VisionSensor>().ToList();
                enemies.ForEach(e => e.gameObject.layer = LayerMask.NameToLayer("Enemy"));
                visionsensors.ForEach(e => e.gameObject.layer = LayerMask.NameToLayer("VisionSensor"));
            }
            player.QuickSwitchWeapon(weaponData);
        }
    }
}