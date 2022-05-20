using System.Collections;
using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Player.Pointer;
using AosSdk.Core.Utils;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Management;

namespace AosSdk.Core.Player.VRPlayer
{
    public class VRPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField] private RayCaster[] handRayCasters;
        [SerializeField] private Grabber leftHandGrabber;
        [SerializeField] private Grabber rightHandGrabber;

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

        public void GrabObject(string objectName, int hand)
        {
            if (hand != 0 && hand != 1)
            {
                Player.Instance.ReportError($"Unknown hand type {hand}");
                return;
            }

            var gameObjectToGrab = GameObject.Find(objectName);

            if (!gameObjectToGrab)
            {
                Player.Instance.ReportError($"Can't grab {objectName}: no object found");
                return;
            }

            var grabbable = gameObjectToGrab.GetComponentInChildren<IGrabbable>();

            if (grabbable == null)
            {
                Player.Instance.ReportError($"Can't grab {objectName}: object is not grabbable");
                return;
            }

            var grabber = (InteractHand) hand == InteractHand.Left ? leftHandGrabber : rightHandGrabber;
            
            gameObjectToGrab.transform.position = grabber.transform.position;

            grabber.TryGrabObject(InteractHand.Desktop, grabbable, gameObjectToGrab);
        }

        public void DropObject(int hand)
        {
            if (hand != 0 && hand != 1)
            {
                Player.Instance.ReportError($"Unknown hand type {hand}");
                return;
            }

            var grabber = (InteractHand) hand == InteractHand.Left ? leftHandGrabber : rightHandGrabber;
            grabber.DropCurrentGrabbedObject();
        }
    }
}