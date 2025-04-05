using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace FS_CombatSystem
{

    public class HPBar : MonoBehaviour
    {
        public MeleeFighter meleeFighter;

        [SerializeField] Image healthBarImg;
        float health;
        Camera cam;

        private void Awake()
        {
            if (meleeFighter == null)
                meleeFighter = GetComponentInParent<MeleeFighter>();

        }

        private void Start()
        {

            health = meleeFighter.CurrentHealth / meleeFighter.MaxHealth;
            cam = Camera.main;
        }

        private void OnEnable()
        {
            meleeFighter.OnGotHit += ControlHealthBar;
        }

        private void OnDisable()
        {
            meleeFighter.OnGotHit -= ControlHealthBar;
        }

        void ControlHealthBar(MeleeFighter meeleFighter, Vector3 hitPoint, float hittingTime, bool isBlockedHit)
        {
            StartCoroutine(LerpHealth());
        }

        IEnumerator LerpHealth()
        {
            var h = meleeFighter.CurrentHealth / meleeFighter.MaxHealth;
            while (health > h)
            {
                health = Mathf.MoveTowards(health, h, Time.deltaTime);
                healthBarImg.fillAmount = health;
                yield return null;
            }
            health = h;
            healthBarImg.fillAmount = health;
            if (health <= 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                this.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            //transform.position = new Vector3(meeleFighter.transform.position.x, transform.position.y, meeleFighter.transform.position.z);
            transform.rotation = Quaternion.LookRotation(cam.transform.forward);
        }
    }
}