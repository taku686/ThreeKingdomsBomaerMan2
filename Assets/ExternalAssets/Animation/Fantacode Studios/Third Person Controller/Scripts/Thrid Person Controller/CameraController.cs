using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static FS_ThirdPerson.PlayerController;

namespace FS_ThirdPerson
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("Target to follow")]
        public Transform followTarget;

        [Tooltip("Default setting of the camera. You can override these settings based on the state of the player.")]
        [SerializeField] CameraSettings defaultSettings;

        [Tooltip("If turned on, the camera will rotate when the player moves sideways.")]
        [SerializeField] bool advancedCameraRotation = true;

        [Tooltip("Layers to check for collision")]
        [SerializeField] LayerMask collisionLayers = 1;
        [Tooltip("This value must be set before starting play mode. It cannot be changed while the game is running.")]
        [SerializeField] bool lockCursor = true;

        [Tooltip("Smooth time to use when camera distance is changed")]
        [SerializeField] float distanceSmoothTime = 0.3f;
        [Tooltip("Smooth time to use when camera distance is changed due to a collision")]
        [SerializeField] float distanceSmoothTimeWhenOcluded = 0f;
        [Tooltip("Smooth time to use when the framing offset is changed")]
        [SerializeField] float framingSmoothTime = 0.5f;
        [SerializeField] float collisionPadding = 0.05f;

        [Tooltip("This can be used to override the camera settings for different states")]
        [SerializeField] List<OverrideSettings> overrideCameraSettings;

        [Tooltip("This value must be set before starting play mode. It cannot be changed while the game is running.")]
        [SerializeField] float nearClipPlane = 0.1f;

        float cameraShakeAmount = 0.6f;

        CameraSettings settings;
        CameraSettings customSettings;

        CameraState currentState;
        Vector3 currentFollowPos;
        float targetDistance, currDistance;
        Vector3 targetFramingOffset, currFramingOffset;

        float distSmoothVel = 0f;
        Vector3 framingSmoothVel, followSmoothVel = Vector3.zero;

        float rotationX;
        float rotationY;
        float yRot;

        float invertXVal;
        float invertYVal;

        Camera camera;
        LocomotionInputManager input;
        PlayerController playerController;
        LocomotionController locomotionController;

        private void Awake()
        {
            camera = GetComponent<Camera>();
            camera.nearClipPlane = nearClipPlane;

            input = FindObjectOfType<LocomotionInputManager>();
            playerController = followTarget.GetComponentInParent<PlayerController>();
            locomotionController = playerController.GetComponent<LocomotionController>();

            playerController.OnStartCameraShake -= StartCameraShake;
            playerController.OnStartCameraShake += StartCameraShake;
            playerController.OnLand -= playerController.OnStartCameraShake;
            playerController.OnLand += playerController.OnStartCameraShake;

            playerController.SetCustomCameraState += SetCustomCameraState;
            playerController.CameraRecoil += CameraRecoil;
        }

        private void Start()
        {
#if !UNITY_ANDROID && !UNITY_IOS
            if (lockCursor)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
#endif
            currentFollowPos = followTarget.position - Vector3.forward * 4;
            settings = defaultSettings;
            currDistance = settings.distance;
            currFramingOffset = settings.framingOffset;

            CalculateNearPlanePoints();
        }

        List<Vector3> nearPlanePoints = new List<Vector3>();
        void CalculateNearPlanePoints()
        {
            var camera = GetComponent<Camera>();
            float z = camera.nearClipPlane;
            float y = Mathf.Tan((camera.fieldOfView / 2) * Mathf.Deg2Rad) * z;
            float x = y * camera.aspect + collisionPadding;

            nearPlanePoints.Add(new Vector3(x, y, z));
            nearPlanePoints.Add(new Vector3(-x, y, z));
            nearPlanePoints.Add(new Vector3(x, -y, z));
            nearPlanePoints.Add(new Vector3(-x, -y, z));
            nearPlanePoints.Add(Vector3.zero);
        }

        CameraState SystemToCameraState(SystemState state)
        {
            if (state == SystemState.Locomotion)
                return (locomotionController.IsCrouching) ? CameraState.Crouching : CameraState.Locomotion;

            return (CameraState)state;
        }

        public void SetCustomCameraState(CameraSettings cameraSettings = null)
        {
            customSettings = cameraSettings;
            if (customSettings == null) {
                var currPlayerState = SystemToCameraState(playerController.CurrentSystemState);
                var overrideSettings = overrideCameraSettings.FirstOrDefault(x => x.state == currPlayerState);
                if (overrideSettings != null)
                    settings = overrideSettings.settings;
                else
                    settings = defaultSettings;
            }
        }

        RecoilInfo GlobalRecoilInfo { get; set; } = new RecoilInfo() { CameraRecoilDuration = 0 };

        public float CameraTotalRecoilDuration { get; set; }

        public void CameraRecoil(RecoilInfo recoilInfo)
        {
            GlobalRecoilInfo.CameraRecoilAmount = Vector3.Scale(Random.insideUnitCircle, recoilInfo.CameraRecoilAmount);

            if (recoilInfo.minRecoilAmount != Vector2.zero)
            {
                GlobalRecoilInfo.CameraRecoilAmount.x = Mathf.Sign(GlobalRecoilInfo.CameraRecoilAmount.x) * Mathf.Max(Mathf.Abs(GlobalRecoilInfo.CameraRecoilAmount.x), recoilInfo.minRecoilAmount.x);
                GlobalRecoilInfo.CameraRecoilAmount.y = Mathf.Max(Mathf.Abs(GlobalRecoilInfo.CameraRecoilAmount.y), recoilInfo.minRecoilAmount.y);
            }

            CameraTotalRecoilDuration = GlobalRecoilInfo.CameraRecoilDuration = recoilInfo.CameraRecoilDuration;

            GlobalRecoilInfo.recoilPhasePercentage = recoilInfo.recoilPhasePercentage;
        }

        private void LateUpdate()
        {
            var currPlayerState = SystemToCameraState(playerController.CurrentSystemState);

            if (customSettings != null)
                settings = customSettings;
            else if (currentState != currPlayerState)
            {
                var overrideSettings = overrideCameraSettings.FirstOrDefault(x => x.state == currPlayerState);
                if (overrideSettings != null)
                    settings = overrideSettings.settings;
                else
                    settings = defaultSettings;
            }
            currentState = currPlayerState;

            var followTarget = settings.followTarget == null ? this.followTarget : settings.followTarget;


            Quaternion targetRotation;
            if (settings.localRotationOffset != Vector2.zero)
            {
                var targetEuler = followTarget.rotation.eulerAngles;
                var rotationX = targetEuler.x + settings.localRotationOffset.y;
                var rotationY = targetEuler.y + settings.localRotationOffset.x;
                targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

            }
            else
            {
                invertXVal = (settings.invertX) ? -1 : 1;
                invertYVal = (settings.invertY) ? -1 : 1;

                rotationX += input.CameraInput.y * invertYVal * settings.sensitivity;
                rotationX = Mathf.Clamp(rotationX, settings.minVerticalAngle, settings.maxVerticalAngle);

                if (input.CameraInput != Vector2.zero)
                    yRot = rotationY += input.CameraInput.x * invertXVal * settings.sensitivity;
                else if (advancedCameraRotation && playerController.CurrentSystemState == SystemState.Locomotion && input.CameraInput.x == 0 && input.DirectionInput.y > -.4f)
                {
                    StartCoroutine(CameraRotDelay());
                    rotationY = Mathf.Lerp(rotationY, yRot, Time.deltaTime * 25);
                }
                targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

            }



            currentFollowPos = Vector3.SmoothDamp(currentFollowPos, followTarget.position, ref followSmoothVel, settings.followSmoothTime);
            if (CameraShakeDuration > 0)
            {
                currentFollowPos += Random.insideUnitSphere * CurrentCameraShakeAmount * cameraShakeAmount * Mathf.Clamp01(CameraShakeDuration);
                CameraShakeDuration -= Time.deltaTime;
            }

            targetFramingOffset = settings.framingOffset;
            currFramingOffset = Vector3.SmoothDamp(currFramingOffset, targetFramingOffset, ref framingSmoothVel, framingSmoothTime);

            var forward = targetRotation * Vector3.up;
            forward.y = 0;

            var right = targetRotation * Vector3.right;

            var focusPosition = currentFollowPos + Vector3.up * currFramingOffset.y + forward * currFramingOffset.z;

            bool collisionAdjusted = false;
            if (settings.enableCameraCollisions)
            {
                RaycastHit hit;
                float closestDistance = settings.distance;

                nearPlanePoints[4] = Vector3.zero;
                for (int i = 0; i < nearPlanePoints.Count; i++)
                {
                    if (Physics.Raycast(focusPosition, (transform.TransformPoint(nearPlanePoints[i]) - focusPosition), out hit, settings.distance, collisionLayers))
                    {
                        if (hit.distance < closestDistance)
                            closestDistance = hit.distance;

                        collisionAdjusted = true;

                        //Debug.DrawRay(focusPosition, (transform.TransformPoint(nearPlanePoints[i]) - focusPosition), Color.red);
                    }
                    //Debug.DrawLine(focusPosition, focusPosition + (transform.TransformPoint(nearPlanePoints[i]) - focusPosition).normalized * settings.distance, hit.point != Vector3.zero ? Color.red : Color.green);


                    //GizmosExtend.drawSphere(transform.TransformPoint(nearPlanePoints[i]), 0.02f, Color.blue);
                    //Debug.DrawLine(hit.point, hit.point + Vector3.forward * 0.08f, Color.yellow);
                }

                targetDistance = Mathf.Clamp(closestDistance, settings.minDistanceFromTarget, closestDistance);
            }
            else
                targetDistance = settings.distance;

            if (!collisionAdjusted)
                currDistance = Mathf.SmoothDamp(currDistance, targetDistance, ref distSmoothVel, distanceSmoothTime);
            else
            {
                if (distanceSmoothTimeWhenOcluded > Mathf.Epsilon)
                    currDistance = Mathf.SmoothDamp(currDistance, targetDistance, ref distSmoothVel, distanceSmoothTimeWhenOcluded);
                else
                    currDistance = targetDistance;
            }


            transform.position = focusPosition - targetRotation * new Vector3(0, 0, currDistance);
            transform.rotation = targetRotation;

            transform.position += transform.right * currFramingOffset.x * currDistance / settings.distance;

            if (GlobalRecoilInfo.CameraRecoilDuration > 0)
            {
                float normalizedTime = 1 - (GlobalRecoilInfo.CameraRecoilDuration / CameraTotalRecoilDuration);
                float recoilProgress;

                if (normalizedTime <= GlobalRecoilInfo.recoilPhasePercentage)
                {
                    recoilProgress = Time.deltaTime / (CameraTotalRecoilDuration * GlobalRecoilInfo.recoilPhasePercentage);
                    rotationY += GlobalRecoilInfo.CameraRecoilAmount.x * recoilProgress;
                    rotationX -= GlobalRecoilInfo.CameraRecoilAmount.y * recoilProgress;
                }
                else
                {
                    recoilProgress = Time.deltaTime / (CameraTotalRecoilDuration * (1 - GlobalRecoilInfo.recoilPhasePercentage));
                    rotationY -= GlobalRecoilInfo.CameraRecoilAmount.x * recoilProgress;
                    rotationX += GlobalRecoilInfo.CameraRecoilAmount.y * recoilProgress;
                }

                GlobalRecoilInfo.CameraRecoilDuration -= Time.deltaTime;
            }
            previousPos = followTarget.transform.position;

        }


        public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);

        bool moving;
        Vector3 previousPos;
        bool inDelay;
        float cameraRotSmooth;


        public float CameraShakeDuration { get; set; } = 0f;
        public float CurrentCameraShakeAmount { get; set; } = 0f;
        public void StartCameraShake(float currentCameraShakeAmount, float shakeDuration)
        {
            CurrentCameraShakeAmount = currentCameraShakeAmount;
            CameraShakeDuration = shakeDuration;
        }

        IEnumerator CameraRotDelay()
        {
            var movDist = Vector3.Distance(previousPos, followTarget.transform.position);
            if (movDist > 0.001f)
            {
                if (!moving)
                {
                    moving = true;
                    inDelay = true;
                    yield return new WaitForSeconds(1.5f);
                    inDelay = false;
                }
            }
            else
            {
                moving = false;
                cameraRotSmooth = 0;
            }

            cameraRotSmooth = Mathf.Lerp(cameraRotSmooth, !inDelay ? 25 : 5, Time.deltaTime);
            yRot = Mathf.Lerp(yRot, yRot + input.DirectionInput.x * invertXVal * 2, Time.deltaTime * cameraRotSmooth);
        }
    }

    [System.Serializable]
    public class CameraSettings : ISerializationCallbackReceiver
    {
        public Transform followTarget;
        public float distance = 2.5f;
        public Vector3 framingOffset = new Vector3(0, 1.5f, 0);
        public float followSmoothTime = 0.2f;

        public Vector2 localRotationOffset;

        [Range(0, 1)]
        public float sensitivity = 0.6f;

        public float minVerticalAngle = -45;
        public float maxVerticalAngle = 70;

        public bool invertX;
        public bool invertY = true;

        public bool enableCameraCollisions = true;
        public float minDistanceFromTarget = 0.2f;

        [SerializeField, HideInInspector]
        private bool serialized = false;
        public void OnAfterDeserialize()
        {
            if (serialized == false)
            {
                distance = 2.5f;
                framingOffset = new Vector3(0, 1.5f, 0);
                followSmoothTime = 0.2f;
                sensitivity = 0.6f;
                minVerticalAngle = -45;
                maxVerticalAngle = 70;
                invertY = true;
                enableCameraCollisions = true;
                minDistanceFromTarget = 0.2f;
            }
        }

        public void OnBeforeSerialize()
        {
            if (serialized)
                return;

            serialized = true;
        }
    }

    [System.Serializable]
    public class OverrideSettings
    {
        public CameraState state;
        public CameraSettings settings;
    }

    // This should be in the same order as SystemState
    public enum CameraState
    {
        Locomotion,
        Parkour,
        Climbing,
        Combat,
        GrapplingHook,
        Swing,
        Other,
        Crouching,
    }
}