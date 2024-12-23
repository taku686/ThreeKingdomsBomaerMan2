using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    /// <summary>
    /// This class controls the settings menu of the Chest Graphics Demo.
    /// </summary>
    public class UIChestGraphicsSettingsPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Text m_TextCounter;
        [SerializeField] private Toggle m_VfxToggle;
        [SerializeField] private Toggle m_GlowsToggle;

        [Header("GameObjects")]
        [SerializeField] private GameObject m_Vfx;
        [SerializeField] private GameObject m_Bg;
        [SerializeField] private ChestGraphicsDemo[] m_Chests;

        private void Start()
        {
            m_TextCounter.text = m_Chests[0].GetCurrentChest() + 1 + "/" + m_Chests[0].GetTotalChests();

            if (m_Vfx == null)
                m_VfxToggle.gameObject.SetActive(false);
        }

        public void OnClickNext(bool next)
        {
            for (int i = 0; i < m_Chests.Length; i++)
                m_Chests[i].ChestChangeGraphics(next);

            m_TextCounter.text = m_Chests[0].GetCurrentChest() + 1 + "/" + m_Chests[0].GetTotalChests();
        }

        public void OnClickOpenClose()
        {
            for (int i = 0; i < m_Chests.Length; i++)
                m_Chests[i].ChestOpenClose();
        }

        public void ToggleGlows()
        {
            for (int i = 0; i < m_Chests.Length; i++)
                m_Chests[i].ChestGlows();
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
