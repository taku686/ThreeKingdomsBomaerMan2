using Cinemachine;
using UnityEngine;

namespace Manager.BattleManager.Camera
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        public void Initialize(Transform target)
        {
            virtualCamera.Follow = target;
            virtualCamera.LookAt = target;
        }
    }
}