using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    /// <summary>
    /// Chest Demo.
    ///
    /// You can learn more about the animations, textures, and materials (shaders) of the chest in this demo.
    ///
    /// This class controls the settings menu of the Chest demo.
    /// </summary>
    public class UIChestSettingsPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Slider m_ChestRotationSlider;
        [SerializeField] private Toggle m_VfxToggle;

        [Header("Buttons")]
        [SerializeField] Button m_ButtonOpens;
        [SerializeField] Button m_ButtonCloses;
        [SerializeField] Button m_ButtonQuickOpens;
        [SerializeField] Button m_ButtonAppears;
        [SerializeField] Button m_ButtonDisappears;
        [SerializeField] Button m_ButtonDrops;
        [SerializeField] Button m_ButtonEmpties;

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

            m_ButtonCloses.interactable = false;
            m_ButtonAppears.interactable = false;
            m_ButtonDrops.interactable = false;
            m_ButtonEmpties.interactable = true;
        }

        private void LateUpdate()
        {
            m_Chest.transform.rotation = Quaternion.Euler(0, m_ChestRotationSlider.value, 0);
        }

        public void ShowHideMenu()
        {
            m_IsShow = !m_IsShow;

            if (m_IsShow)
                transform.localPosition = new Vector3(0, transform.localPosition.y + 110, 0);
            else
                transform.localPosition = new Vector3(0, transform.localPosition.y - 110, 0);
        }

        public void ToggleGlows()
        {
            m_Chest.GetComponent<ChestDemo>().ChestGlows();
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

        public void OnClickOpens()
        {
            m_Chest.GetComponent<ChestDemo>().ChestOpen();

            m_ButtonOpens.interactable = false;
            m_ButtonCloses.interactable = true;
            m_ButtonQuickOpens.interactable = false;
        }

        public void OnClickCloses()
        {
            m_Chest.GetComponent<ChestDemo>().ChestClose();

            m_ButtonOpens.interactable = true;
            m_ButtonCloses.interactable = false;
            m_ButtonQuickOpens.interactable = true;
        }

        [System.Obsolete]
        public void OnClickQuickOpens()
        {
            m_Chest.GetComponent<ChestDemo>().ChestQuickOpens();
        }

        public void OnClickAppears()
        {
            m_Chest.GetComponent<ChestDemo>().ChestAppear();

            m_ButtonOpens.interactable = true;
            m_ButtonCloses.interactable = false;
            m_ButtonQuickOpens.interactable = true;
            m_ButtonAppears.interactable = false;
            m_ButtonDisappears.interactable = true;
            m_ButtonDrops.interactable = false;
            m_ButtonEmpties.interactable = true;
        }

        public void OnClickDisappears()
        {
            m_Chest.GetComponent<ChestDemo>().ChestDisappear();

            m_ButtonOpens.interactable = false;
            m_ButtonCloses.interactable = false;
            m_ButtonQuickOpens.interactable = false;
            m_ButtonAppears.interactable = true;
            m_ButtonDisappears.interactable = false;
            m_ButtonDrops.interactable = true;
            m_ButtonEmpties.interactable = false;
        }

        [System.Obsolete]
        public void OnClickDrops()
        {
            m_Chest.GetComponent<ChestDemo>().ChestDrop();

            m_ButtonOpens.interactable = true;
            m_ButtonCloses.interactable = false;
            m_ButtonQuickOpens.interactable = true;
            m_ButtonAppears.interactable = false;
            m_ButtonDisappears.interactable = true;
            m_ButtonDrops.interactable = false;
            m_ButtonEmpties.interactable = true;
        }

        public void OnClickEmpties()
        {
            m_Chest.GetComponent<ChestDemo>().ChestEmpty();

            m_ButtonOpens.interactable = false;
            m_ButtonCloses.interactable = false;
            m_ButtonQuickOpens.interactable = false;
            m_ButtonAppears.interactable = false;
            m_ButtonDisappears.interactable = true;
            m_ButtonDrops.interactable = false;
            m_ButtonEmpties.interactable = false;
        }
    }
}
