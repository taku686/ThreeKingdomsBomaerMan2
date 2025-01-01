using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    /// <summary>
    /// This class controls the settings menu of the LootBox Demo.
    /// </summary>
    public class UILootBoxSettingsPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Slider m_ChestRotationSlider;
        [SerializeField] private Toggle m_VfxToggle;

        [Header("GameObjects")]
        [SerializeField] private GameObject m_Chest;
        [SerializeField] private GameObject m_Vfx;
        [SerializeField] private GameObject m_Bg;

        private bool m_IsShow;

        private void Start()
        {
            m_IsShow = false;

            if (m_Vfx == null)
                m_VfxToggle.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            m_Chest.transform.rotation = Quaternion.Euler(0, m_ChestRotationSlider.value, 0);
        }

        public void ShowHideMenu()
        {
            m_IsShow = !m_IsShow;

            if (m_IsShow)
                transform.localPosition = new Vector3(0, transform.localPosition.y + 44 + 64, 0);
            else
                transform.localPosition = new Vector3(0, transform.localPosition.y - 44 - 64, 0);
        }

        public void ToggleGlows()
        {
            m_Chest.GetComponent<LootBoxDemo>().ChestGlows();
        }

        public void ToggleVFX()
        {
            bool b = !m_Vfx.activeSelf;
            m_Vfx.SetActive(b);
        }

        public void OnClickChangeBG()
        {
            m_Bg.GetComponent<RewardRoomDemo>().ChangeBGColor();
        }
    }
}
