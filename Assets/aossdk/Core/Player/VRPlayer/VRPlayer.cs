using System.Collections;
using AosSdk.Core.Player.Pointer;
using AosSdk.Core.Utils;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Management;

namespace AosSdk.Core.Player.VRPlayer
{
    public class VRPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField] private AosSDKSettings sdkSettings;
        [SerializeField] private RayCaster[] handRayCasters;
        public XROrigin xrOrigin;

        public bool CanMove { get; set; } = true;

        public void TeleportTo(Transform target)
        {
            var targetPosition = target.position;
            TeleportTo(targetPosition.x, targetPosition.y, targetPosition.z);
        }

        public void TeleportTo(float x, float y, float z)
        {
            if (!CanMove)
            {
                return;
            }

            xrOrigin.MoveCameraToWorldLocation(new Vector3(x, y, z) + xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight);
        }

        public void TeleportTo(string objectName)
        {
            var target = GameObject.Find(objectName)?.transform;

            if (!target)
            {
                RuntimeData.Instance.CurrentPlayer.ReportError($"Teleport to object failed, no object with name {objectName} found");
                return;
            }

            var targetPosition = target.position;
            TeleportTo(targetPosition.x, targetPosition.y, targetPosition.z);
        }

        public void EnableCamera(bool value)
        {
            xrOrigin.Camera.enabled = value;
        }

        public void EnableRayCaster(bool value)
        {
            foreach (var raycaster in handRayCasters)
            {
                raycaster.enabled = value;
            }
        }

        public void InitializeOpenXR()
        {
            StartCoroutine(InitializeOpenXRRoutine());
        }

        private static IEnumerator InitializeOpenXRRoutine()
        {
            yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
            if (XRGeneralSettings.Instance.Manager.activeLoader == null)
            {
                Player.Instance.ReportError("InitializeOpenXR failed - no XR loader found");
            }

            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }
}