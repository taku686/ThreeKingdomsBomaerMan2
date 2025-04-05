using FS_CombatSystem;
using UnityEngine;

namespace FS_ThirdPerson
{
    public class AnimationEventExamples : MonoBehaviour
    {
        // Example functions that can be called by the Animation Events.
        // First parameter of the function should be should be GameObject. Only then, animation events will be able to call them

        public void ChangeCamera(GameObject obj, CameraSettings cameraSettings)
        {
            var playerController = obj.GetComponent<PlayerController>();
            var cameraController = playerController?.cameraGameObject.GetComponent<CameraController>();
            cameraController.SetCustomCameraState(cameraSettings);
        }
        public void ResetCamera(GameObject obj)
        {
            var playerController = obj.GetComponent<PlayerController>();
            var cameraController = playerController?.cameraGameObject.GetComponent<CameraController>();
            cameraController.SetCustomCameraState(null);
        }

        public void PlayInSlowMotion(GameObject obj, float slowMotionTime = 0.5f, bool onlyForLastEnemy = false)
        {
            if (!onlyForLastEnemy || (onlyForLastEnemy && EnemyManager.i.enemiesInRange.Count == 1))
            {
                Time.timeScale = slowMotionTime;
            }
        }

        public void ResetSlowMotion(GameObject obj)
        {
            Time.timeScale = 1;
        }

        public void PlayEffect(GameObject obj, GameObject hitEffect, HumanBodyBones handBone)
        {
            var fighterAnimator = obj.GetComponent<MeleeFighter>().GetComponent<Animator>();
            var effectSpawnPoint = fighterAnimator.GetBoneTransform(handBone).position;
            var effect = Instantiate(hitEffect, effectSpawnPoint, Quaternion.identity);
            Destroy(effect, 2);
        }
    }
}