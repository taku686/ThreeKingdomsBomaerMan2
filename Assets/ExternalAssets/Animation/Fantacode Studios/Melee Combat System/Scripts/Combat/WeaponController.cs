using UnityEngine;
namespace FS_CombatSystem
{
    public class WeaponController : MonoBehaviour
    {

        MeleeFighter meeleFighter;
        public WeaponData weaponData;
        public WeaponData weaponData1;
        private void OnEnable()
        {
            meeleFighter = GetComponent<MeleeFighter>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                meeleFighter.EquipWeapon(weaponData);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                meeleFighter.EquipWeapon(weaponData1);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                meeleFighter.UnEquipWeapon();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                meeleFighter.ResetFighter();
            }

        }
    }
}