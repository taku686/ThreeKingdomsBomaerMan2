using FS_ThirdPerson;
using System.Collections;
using UnityEngine;
namespace FS_CombatSystem
{
    public class CombatEffects : MonoBehaviour
    {
        MeleeFighter meleeFighter;
        PlayerController player;
        private void Awake()
        {
            meleeFighter = GetComponent<MeleeFighter>();
            player = FindAnyObjectByType<PlayerController>();
        }

        private void Start()
        {
            meleeFighter.OnAttack += (target) =>
            {
                var strikeSound = meleeFighter.CurrAttack?.StrikeSound;
                if (strikeSound != null)
                    PlaySfx(strikeSound);
            };

            meleeFighter.OnGotHit += (MeleeFighter attacker, Vector3 hitPoint, float hittingTime, bool isBlockedHit) =>
            {
                if (attacker?.CurrAttack == null) return;

                var attack = attacker.CurrAttack;

                // Play Sfx
                AudioClip hitSound = meleeFighter.IsBlocking ? attack.BlockedHitSound : attack.HitSound;

                if (hitSound != null)
                    PlaySfx(hitSound);

                if (!meleeFighter.IsBlocking && attack.ReactionSound != null)
                    PlaySfx(attack.ReactionSound);

                // Play Vfx
                StartCoroutine(PlayVfx(attacker, hitPoint, hittingTime));
            };

            meleeFighter.OnWeaponEquipAction += (WeaponData weaponData, bool playEquipSound) =>
            {
                if (!playEquipSound) return;
                var equipSound = weaponData.WeaponEquipSound;
                if (equipSound != null)
                    PlaySfx(equipSound);
            };

            meleeFighter.OnWeaponUnEquipAction += (WeaponData weaponData, bool playUnEquipSound) =>
            {
                if (!playUnEquipSound) return;
                var unEquipSound = weaponData?.WeaponUnEquipSound;
                if (unEquipSound != null)
                    PlaySfx(unEquipSound);
            };

            meleeFighter.OnEnableHit += (AttachedWeapon handler) => StartCoroutine(EnableTrail(handler));
        }

        void PlaySfx(AudioClip clip)
        {
            GameObject sfx = new GameObject();
            sfx.transform.position = meleeFighter.transform.position;
            var audioSource = sfx.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(sfx, 1.5f);
        }

        IEnumerator PlayVfx(MeleeFighter attacker, Vector3 hitPoint, float hittingTime)
        {
            var curAttack = attacker.CurrAttack;
            if (hitPoint == Vector3.zero && hittingTime >= 0)
            {
                yield return new WaitForSeconds(hittingTime);
                hitPoint = meleeFighter.GetHitPoint(attacker);
            }
            player.OnStartCameraShake.Invoke(curAttack.CameraShakeAmount, curAttack.CameraShakeDuration);

            var hitEffect = meleeFighter.IsBlocking ? attacker.CurrAttack.BlockedHitEffect : attacker.CurrAttack.HitEffect;
            if (hitEffect == null)
                yield break;
            var vfxObj = Instantiate(hitEffect, hitPoint, Quaternion.identity);
            vfxObj.SetActive(false);
            vfxObj.transform.position = hitPoint;
            vfxObj.SetActive(true);
            Destroy(vfxObj, 1.5f);
        }

        IEnumerator EnableTrail(AttachedWeapon handler)
        {
            if (handler?.trail == null) yield break;

            handler.trail.gameObject.SetActive(true);
            var impactEndTime = meleeFighter.CurrAttack.ImpactEndTime;
            float timer = 0;
            while (timer < impactEndTime)
            {
                if (meleeFighter.State != FighterState.Attacking)
                    break;

                timer += Time.deltaTime;
                yield return null;
            }
            handler.trail.gameObject.SetActive(false);
        }
    }
}