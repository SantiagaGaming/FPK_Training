using System;
using System.Collections;
using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Management;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    [RequireComponent(typeof(XROrigin), typeof(CharacterController))]
    public class VRPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField] private RayCaster[] handRayCasters;
        [SerializeField] private Grabber leftHandGrabber;
        [SerializeField] private Grabber rightHandGrabber;
        [SerializeField] private Camera _eventCamera;
        [SerializeField] private Camera _playerCamera;

        private CharacterController _characterController;
        private XROrigin _xrOrigin;
        private FadeController _fadeController;

        public bool CanMove { get; set; } = true;
        public bool CanRun { get; set; } = true;

        public Camera EventCamera
        {
            get => _eventCamera;
            set { }
        }

        public GameObject GameObject
        {
            get => gameObject;
            set { }
        }

        public FadeController FadeController
        {
            get => _fadeController;
            set
            {
                _fadeController = value;

                var fadeControllerTransform = _fadeController.transform;

                fadeControllerTransform.parent = _playerCamera.transform;
                fadeControllerTransform.localPosition = new Vector3(0, 0, _playerCamera.nearClipPlane + 0.01f);
            }
        }

        public void Init()
        {
            _characterController = GetComponent<CharacterController>();
            _xrOrigin = GetComponent<XROrigin>();

            StartCoroutine(InitializeOpenXRRoutine());
        }

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

            _xrOrigin.MoveCameraToWorldLocation(new Vector3(x, y, z) + _xrOrigin.Origin.transform.up * _xrOrigin.CameraInOriginSpaceHeight);
        }

        public void TeleportTo(string objectName)
        {
            var target = GameObject.Find(objectName)?.transform;

            if (target == null)
            {
                Player.Instance.ReportError($"Teleport to object failed, no object with name {objectName} found");
                return;
            }

            var targetPosition = target.position;
            TeleportTo(targetPosition.x, targetPosition.y, targetPosition.z);
        }

        public void ForwardTo(Transform target)
        {
            // should not be implemented
        }

        public void ReleaseForwarding()
        {
            // should not be implemented
        }

        public void EnableCamera(bool value)
        {
            _xrOrigin.Camera.enabled = value;
        }

        public void EnableRayCaster(bool value)
        {
            foreach (var raycaster in handRayCasters)
            {
                raycaster.enabled = value;
            }
        }

        private IEnumerator InitializeOpenXRRoutine()
        {
            yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
            if (XRGeneralSettings.Instance.Manager.activeLoader == null)
            {
                Player.Instance.ReportError("InitializeOpenXR failed - no XR loader found");
            }

            XRGeneralSettings.Instance.Manager.StartSubsystems();

            _eventCamera.fieldOfView = _playerCamera.fieldOfView;

            UpdateCharacterController();
        }

        private void OnDestroy()
        {
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            if (XRGeneralSettings.Instance.Manager.activeLoader)
            {
                XRGeneralSettings.Instance.Manager.activeLoader.Stop();
            }

            XRGeneralSettings.Instance.Manager.StopSubsystems();
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

        public void SetCrouchState(bool state)
        {
        }

        private void Update()
        {
            if (Launcher.Instance.SdkSettings.vrMovementType != VrMovementType.Locomotion)
            {
                return;
            }

            UpdateCharacterController();
        }

        protected virtual void UpdateCharacterController()
        {
            if (_xrOrigin == null || _characterController == null)
            {
                return;
            }

            var height = _xrOrigin.CameraInOriginSpaceHeight;

            var center = Launcher.Instance.SdkSettings.vrHeadCollisionType switch
            {
                VrHeadCollisionType.Collide => _xrOrigin.CameraInOriginSpacePos,
                VrHeadCollisionType.FadeOut => Vector3.zero,
                _ => throw new ArgumentOutOfRangeException()
            };

            center.y = height / 2f + _characterController.skinWidth;

            _characterController.height = height;
            _characterController.center = center;
        }

        public void FadeIn(float speed, bool isInstant)
        {
            StartCoroutine(FadeController.FadeIn(speed, isInstant));
        }

        public void FadeOut(float speed, bool isInstant)
        {
            StartCoroutine(FadeController.FadeOut(speed, isInstant));
        }
    }
}