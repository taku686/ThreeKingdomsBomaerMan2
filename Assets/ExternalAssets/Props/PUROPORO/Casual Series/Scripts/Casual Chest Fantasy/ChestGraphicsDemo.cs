using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    public class ChestGraphicsDemo : MonoBehaviour
    {
        public bool IsURPDemo;
        public MaterialType MaterialType;

        [Header("Chest")]
        [SerializeField] private SOChestsDB m_ChestsDB; // ScriptableObject
        private SkinnedMeshRenderer m_ChestMeshRenderer;
        private int m_CurrentChest;
        private bool m_IsGlows;

        private Material m_Material;
        private const string c_BaseMap = "_BaseMap";
        private const string c_MaskMap = "_MaskMap";
        private const string c_GlowingPower = "_VFXGlowingPower";

        private Animator m_Anim;
        private int m_CurrentAnimState;
        private static readonly int c_AnimOpens = Animator.StringToHash("Opens");
        private static readonly int c_AnimCloses = Animator.StringToHash("Closes");

        private void Start()
        {
            m_ChestMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            m_Material = m_ChestMeshRenderer.materials[0];
            m_Anim = GetComponent<Animator>();
            m_CurrentAnimState = c_AnimCloses;

            m_CurrentChest = 0;
            ChangeGraphics();
        }

        private void LateUpdate()
        {
            if (m_IsGlows)
                m_Material.SetFloat(c_GlowingPower, Mathf.SmoothStep(0, 0.4f, Mathf.PingPong(Time.time, 1)));
        }

        public int GetCurrentChest()
        {
            return m_CurrentChest;
        }

        public int GetTotalChests()
        {
            return m_ChestsDB.GetCount();
        }

        /// <summary>
        /// Change the chest's look with textures from chest database (scriptable objects).
        /// </summary>
        public void ChestChangeGraphics(bool next)
        {
            if (next)
            {
                m_CurrentChest++;

                if (m_CurrentChest >= m_ChestsDB.GetCount())
                    m_CurrentChest = 0;
            }
            else
            {
                m_CurrentChest--;

                if (m_CurrentChest < 0)
                    m_CurrentChest = m_ChestsDB.GetCount() - 1;
            }

            ChangeGraphics();
        }

        private void ChangeGraphics()
        {
            SOChest tempChest = m_ChestsDB.GetChest(m_CurrentChest);

            m_ChestMeshRenderer.sharedMesh = tempChest.GetMesh();
            m_ChestMeshRenderer.material = tempChest.GetMaterial(MaterialType, IsURPDemo);
            m_ChestMeshRenderer.materials[0].SetTexture(c_BaseMap, tempChest.GetBaseTexture());
            m_ChestMeshRenderer.materials[0].SetTexture(c_MaskMap, tempChest.GetMaskMap());

            m_Material = m_ChestMeshRenderer.materials[0];
        }

        /// <summary>
        /// This function makes the chest glows (on/off setting). Glow-animation is animated with the LateUpdate function.
        /// </summary>
        public void ChestGlows()
        {
            m_IsGlows = !m_IsGlows;

            if (!m_IsGlows)
                m_Material.SetFloat(c_GlowingPower, 0);
        }

        /// <summary>
        /// This function animatedly opens or closes the chest.
        /// </summary>
        public void ChestOpenClose()
        {
            if (m_CurrentAnimState == c_AnimCloses)
            {
                m_Anim.CrossFade(c_AnimOpens, 0, 0);
                m_CurrentAnimState = c_AnimOpens;

                return;
            }

            if (m_CurrentAnimState == c_AnimOpens)
            {
                m_Anim.CrossFade(c_AnimCloses, 0, 0);
                m_CurrentAnimState = c_AnimCloses;

                return;
            }
        }
    }
}
