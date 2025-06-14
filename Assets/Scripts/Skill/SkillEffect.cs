using UnityEngine;

namespace Skill
{
    public class SkillEffect : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            Destroy(gameObject);
        }
    }
}