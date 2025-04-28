using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class ME_PerPlatformSettings : MonoBehaviour
{
    public bool DisableOnMobiles;
    public GameObject[] Particles;
    [Range(0.1f, 1)] public float ParticleBudgetForMobiles = 1f;
    // Use this for initialization
    private bool isMobile;

    void Awake()
    {
        isMobile = IsMobilePlatform();
        if (isMobile)
        {
            if (DisableOnMobiles)
            {
                foreach (var ps in Particles)
                {
                    ps.SetActive(false);
                }
               
            }
            else
            {
                if(ParticleBudgetForMobiles < 0.99f) ChangeParticlesBudget(ParticleBudgetForMobiles);
            }
        }
    }

    private bool defaultOpaueColorUsing;
    private bool defaultDepthUsing;


    void OnEnable()
    {
        var cam = Camera.main;

        if (cam == null) return;
        var addCamData = cam.GetComponent<UniversalAdditionalCameraData>();
        if (addCamData != null)
        {
            defaultOpaueColorUsing  = addCamData.requiresColorTexture;
            defaultDepthUsing = addCamData.requiresDepthTexture;
            addCamData.requiresColorTexture = true;
            addCamData.requiresDepthTexture = true;
        }
    }

    void OnDisable()
    {
        var cam = Camera.main;

        if (cam == null) return;
        var addCamData                                          = cam.GetComponent<UniversalAdditionalCameraData>();
        if (addCamData != null)
        {
            addCamData.requiresColorTexture = defaultOpaueColorUsing;
            addCamData.requiresDepthTexture = defaultDepthUsing;
        }
    }


    bool IsMobilePlatform()
    {
        bool isMobile = false;
#if UNITY_EDITOR
        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android
            || EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS
            || EditorUserBuildSettings.activeBuildTarget == BuildTarget.WSAPlayer)
            isMobile = true;
#endif
        if (Application.isMobilePlatform) isMobile = true;
        return isMobile;
    }

    void ChangeParticlesBudget(float particlesMul)
    {
        foreach (var go in Particles)
        {
            var particles = go.GetComponent<ParticleSystem>();
            var main = particles.main;
            main.maxParticles = Mathf.Max(1, (int) (main.maxParticles * particlesMul));

            var emission = particles.emission;
            if (!emission.enabled) return;

            var rateOverTime = emission.rateOverTime;
            {
                if (rateOverTime.constantMin > 1) rateOverTime.constantMin *= particlesMul;
                if (rateOverTime.constantMax > 1) rateOverTime.constantMax *= particlesMul;
                emission.rateOverTime = rateOverTime;
            }

            var rateOverDistance = emission.rateOverDistance;
            if (rateOverDistance.constantMin > 1)
            {
                if (rateOverDistance.constantMin > 1) rateOverDistance.constantMin *= particlesMul;
                if (rateOverDistance.constantMax > 1) rateOverDistance.constantMax *= particlesMul;
                emission.rateOverDistance = rateOverDistance;
            }

            ParticleSystem.Burst[] burst = new ParticleSystem.Burst[emission.burstCount];
            emission.GetBursts(burst);
            for (var i = 0; i < burst.Length; i++)
            {

                if (burst[i].minCount > 1) burst[i].minCount = (short) (burst[i].minCount * particlesMul);
                if (burst[i].maxCount > 1) burst[i].maxCount = (short) (burst[i].maxCount * particlesMul);
            }

            emission.SetBursts(burst);
        }
    }
}
