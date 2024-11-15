using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FORGE3D
{
    public class F3DTurretUI : MonoBehaviour
    {
        public List<F3DFXController> _fxControllers = new List<F3DFXController>();

        public Text WeaponTypeText;

        // GUI captions
        private string[] _fxTypeName =
        {
            "Vulcan", "Sologun", "Sniper", "Shotgun", "Seeker", "Railgun", "Plasmagun", "Plasma beam",
            "Heavy plasma beam", "Lightning gun", "Flamethrower", "Pulse laser"
        };

        // Use this for initialization
        private void Awake()
        {
            _fxControllers.AddRange(FindObjectsOfType<F3DFXController>());
        }

        private void Start()
        {
            if (_fxControllers.Count > 0)
                SetWeaponTypeText();
        }

        void SetWeaponTypeText()
        {
            WeaponTypeText.text = _fxTypeName[(int) _fxControllers[0].DefaultFXType];
        }

        public void OnButtonNext()
        {
            ToggleWeaponType(true);
        }

        public void OnButtonPrevious()
        {
            ToggleWeaponType(false);
        }

        private void ToggleWeaponType(bool next)
        {
            foreach (var _fx in _fxControllers)
            {
                if (next) _fx.NextWeapon();
                else _fx.PrevWeapon();
                _fx.Stop();
            }

            SetWeaponTypeText();
        }

        private void Update()
        {
            // Switch weapon types using keyboard keys
            if (Input.GetKeyDown(KeyCode.E))
                OnButtonNext();
            else if (Input.GetKeyDown(KeyCode.Q))
                OnButtonPrevious();
        }
    }
}