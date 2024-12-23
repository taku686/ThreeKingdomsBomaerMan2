using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// Chest Demo.
    ///
    /// You can learn more about the animations, textures, and materials (shaders) of the chest in this demo.
    ///
    /// The animations and particle effects of the chest are managed in this class.
    ///
    /// Please, pay close attention to how the CrossFade animation method is used in the demo.
    /// Check https://docs.unity3d.com/ScriptReference/Animation.CrossFade.html
    ///
    /// The database, which is made possible by the use of ScriptableObjects,
    /// has a list of the various chests. For more information about these,
    /// please check https://docs.unity3d.com/Manual/class-ScriptableObject.html
    /// </summary>
    public class ChestDemo : MonoBehaviour
    {
        public bool IsURPDemo;
        public MaterialType MaterialType;

        [Header("Chest")]
        [SerializeField] private SOChestsDB m_ChestsDB; // ScriptableObject
        private SkinnedMeshRenderer m_ChestMeshRenderer;
        private bool m_IsEmpty;
        private bool m_IsGlows;

        private Material m_Material;
        private const string c_BaseMap = "_BaseMap";
        private const string c_MaskMap = "_MaskMap";
        private const string c_GlowingPower = "_VFXGlowingPower";

        // Members for CrossFade-animation method.
        // Check https://docs.unity3d.com/ScriptReference/Animation.CrossFade.html
        private Animator m_Anim;
        private int m_CurrentAnimState;
        private static readonly int c_AnimIdle = Animator.StringToHash("Idle");
        private static readonly int c_AnimOpens = Animator.StringToHash("Opens");
        private static readonly int c_AnimCloses = Animator.StringToHash("Closes");
        private static readonly int c_AnimDisappears = Animator.StringToHash("Disappears");
        private static readonly int c_AnimAppears = Animator.StringToHash("Appears");
        private static readonly int c_AnimDrops = Animator.StringToHash("Drops");
        private static readonly int c_AnimQuickOpens = Animator.StringToHash("Quick Opens");

        [Header("Particles")]
        [SerializeField] private ParticleSystem m_ParticlesSpawnChest;
        [SerializeField] private ParticleSystem m_ParticlesSpawnCard;
        [SerializeField] private ParticleSystem m_ParticlesDisappearChest;
        [SerializeField] private ParticleSystem m_ParticlesChestOpen;

        private void Start()
        {
            m_ChestMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            m_Material = m_ChestMeshRenderer.materials[0];
            //m_Material = GetComponentInChildren<SkinnedMeshRenderer>().materials[0];
            m_Anim = GetComponent<Animator>();

            ChestChangeGraphics();

            m_IsEmpty = false;
            m_IsGlows = true;
        }

        private void LateUpdate()
        {
            if (m_IsGlows && !m_IsEmpty)
                m_Material.SetFloat(c_GlowingPower, Mathf.SmoothStep(0, 0.4f, Mathf.PingPong(Time.time, 1)));
        }

        /// <summary>
        /// Quickly hide the chest (with animation).
        /// </summary>
        public void ChestHide()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;

            m_Anim.CrossFade(c_AnimDisappears, 0, 0);
            m_CurrentAnimState = c_AnimDisappears;
        }

        /// <summary>
        /// Change the chest's look with textures from chest database (scriptable objects).
        /// </summary>
        public void ChestChangeGraphics()
        {
            SOChest tempChest = m_ChestsDB.GetChest(-1);

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
        /// This function makes the chest appear empty when it is empty.
        /// </summary>
        public void ChestEmpty()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;
            if (m_IsEmpty) return;

            m_IsEmpty = true;

            m_ParticlesChestOpen.Stop();
            m_ParticlesChestOpen.Clear();

            StartCoroutine(FadeToBlack());
        }

        /// <summary>
        /// Fade to Black animation (coroutine).
        /// </summary>
        IEnumerator FadeToBlack()
        {
            for (float f = 0; f >= -0.4f; f -= 0.01f)
            {
                m_Material.SetFloat(c_GlowingPower, f);
                yield return null;
            }
        }

        /// <summary>
        /// This function animatedly opens the chest.
        /// </summary>
        public void ChestOpen()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;
            if (m_CurrentAnimState == c_AnimOpens) return;

            m_Anim.CrossFade(c_AnimOpens, 0, 0);
            m_CurrentAnimState = c_AnimOpens;

            m_ParticlesChestOpen.Play();
        }

        /// <summary>
        /// Animate the chest quickly to open and then closes it.
        /// </summary>
        [System.Obsolete]
        public void ChestQuickOpens()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;
            if (m_CurrentAnimState == c_AnimOpens) return;

            m_Anim.Play(c_AnimQuickOpens, 0, 0);
            m_CurrentAnimState = c_AnimQuickOpens;

            m_ParticlesSpawnCard.Play();
        }

        /// <summary>
        /// This function closes the chest.
        /// </summary>
        public void ChestClose()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;
            if (m_CurrentAnimState == c_AnimCloses) return;
            if (m_CurrentAnimState != c_AnimOpens) return;

            m_Anim.CrossFade(c_AnimCloses, 0, 0);
            m_CurrentAnimState = c_AnimCloses;

            m_ParticlesChestOpen.Stop();
        }

        /// <summary>
        /// Dispose of the chest.
        /// </summary>
        public void ChestDisappear()
        {
            if (m_CurrentAnimState == c_AnimDisappears) return;

            m_Anim.CrossFade(c_AnimDisappears, 0.5f, 0);
            m_CurrentAnimState = c_AnimDisappears;

            m_ParticlesChestOpen.Stop();
            m_ParticlesChestOpen.Clear();
            m_ParticlesDisappearChest.Play();
        }

        /// <summary>
        /// Animate the chest to appear out of nowhere.
        /// </summary>
        public void ChestAppear()
        {
            if (m_CurrentAnimState != c_AnimDisappears) return;
            if (m_CurrentAnimState == c_AnimAppears) return;

            ChestChangeGraphics();

            m_Material.SetFloat(c_GlowingPower, 0);
            m_IsEmpty = false;

            m_Anim.CrossFade(c_AnimAppears, 0, 0);
            m_CurrentAnimState = c_AnimAppears;

            m_ParticlesDisappearChest.Play();
        }

        /// <summary>
        /// Animate the chest to drop from the sky.
        /// </summary>
        [System.Obsolete]
        public void ChestDrop()
        {
            if (m_CurrentAnimState != c_AnimDisappears) return;
            if (m_CurrentAnimState == c_AnimDrops) return;

            ChestChangeGraphics();

            m_Material.SetFloat(c_GlowingPower, 0);
            m_IsEmpty = false;

            m_Anim.CrossFade(c_AnimDrops, 0, 0);
            m_CurrentAnimState = c_AnimDrops;

            m_ParticlesSpawnChest.startDelay = 0.3f;
            m_ParticlesSpawnChest.Play();
        }
    }
}
