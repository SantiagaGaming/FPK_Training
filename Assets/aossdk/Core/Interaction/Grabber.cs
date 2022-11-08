using AosSdk.Core.Input;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Interaction
{
    public enum GrabType
    {
        HoldGrab,
        ToggleGrab
    }

    public class Grabber : MonoBehaviour
    {
        [SerializeField] private SharedInput sharedInput;
        [SerializeField] private Renderer handRenderer;

        private GameObject _currentGrabbedGameObject;
        private IGrabbable _currentGrabbable;
        private Rigidbody _currentGrabbedRigidbody;
        private Transform _thisTransform;
        private InteractHand _currentInteractHand;
        private DesktopGrabbedZoomOverrider _currentZoomOverrider;
        private float _currentMinimumGrabbedZoomLevel;
        private float _currentMaximumGrabbedZoomLevel;

        internal (bool, bool) HandleCurrentGrabbable(InteractHand interactHand, IClickAble clickAble)
        {
            if (_currentGrabbedRigidbody == null)
            {
                return (false, false);
            }

            bool shouldDrop;

            if (_currentGrabbable.GrabType == GrabType.HoldGrab)
            {
                shouldDrop = sharedInput.IsHoldingGrab == false;
            }
            else
            {
                shouldDrop = sharedInput.IsGrabbing;
            }

            if (shouldDrop)
            {
                DropCurrentGrabbedObject();

                return (false, true);
            }

            if (interactHand == InteractHand.Desktop)
            {
                var grabOffset = _thisTransform.localPosition.z;
                grabOffset += grabOffset * sharedInput.ZoomValue * 0.1f;
                _thisTransform.localPosition = Vector3.forward * Mathf.Clamp(grabOffset, _currentMinimumGrabbedZoomLevel, _currentMaximumGrabbedZoomLevel);
            }

            if (!sharedInput.IsClicking || _currentGrabbedGameObject == null)
            {
                return (true, false);
            }

            if (clickAble is {IsClickable: true})
            {
                clickAble.OnClicked(interactHand);
            }

            return (true, false);
        }

        internal void TryGrabObject(InteractHand interactHand, IGrabbable grabbable, GameObject gameObjectToGrab)
        {
            _currentGrabbedGameObject = gameObjectToGrab;
            var objectToGrabRigidbody = _currentGrabbedGameObject.GetComponent<Rigidbody>();

            _currentZoomOverrider = _currentGrabbedGameObject.GetComponent<DesktopGrabbedZoomOverrider>();

            if (!objectToGrabRigidbody)
            {
                return;
            }

            _currentGrabbable = grabbable;

            if (_currentGrabbable.IsGrabbed)
            {
                return;
            }

            _currentGrabbable.OnGrabbed(interactHand);

            _currentGrabbable.IsGrabbed = true;

            _currentGrabbedRigidbody = objectToGrabRigidbody;

            _currentInteractHand = interactHand;

            _currentMinimumGrabbedZoomLevel = _currentZoomOverrider ? _currentZoomOverrider.minZoomDistance : Launcher.Instance.SdkSettings.desktopGrabMinZoomDistance;
            _currentMaximumGrabbedZoomLevel = _currentZoomOverrider ? _currentZoomOverrider.maxZoomDistance : Launcher.Instance.SdkSettings.desktopGrabMaxZoomDistance;

            if (interactHand == InteractHand.Desktop)
            {
                _thisTransform.localPosition = Vector3.forward * (_currentMaximumGrabbedZoomLevel - _currentMinimumGrabbedZoomLevel) / 2;
            }

            if (!handRenderer || !Launcher.Instance.SdkSettings.hideHandOnGrab)
            {
                return;
            }

            handRenderer.enabled = false;
        }

        internal void DropCurrentGrabbedObject()
        {
            if (_currentGrabbable == null)
            {
                PlayerModule.Player.Instance.ReportError($"Can't drop object from {_currentInteractHand.ToString()}: nothing grabbed");
                return;
            }

            _currentGrabbable.OnUnGrabbed(_currentInteractHand);

            _currentGrabbable.IsGrabbed = false;

            _currentGrabbedGameObject = null;
            _currentGrabbedRigidbody = null;

            _currentGrabbable = null;

            if (handRenderer && !handRenderer.enabled)
            {
                handRenderer.enabled = true;
            }
        }

        private void Start()
        {
            _thisTransform = transform;
        }

        private void FixedUpdate()
        {
            if (_currentGrabbedRigidbody == null)
            {
                return;
            }

            Vector3 grabPositionOffset;
            Quaternion grabRotationOffset;

            var grabbedObjectTransform = _currentGrabbedRigidbody.transform;

            var grabAnchor = _currentGrabbable.GrabAnchor;

            if (grabAnchor)
            {
                grabPositionOffset = grabAnchor.position;
                grabRotationOffset = grabAnchor.rotation;
            }
            else
            {
                grabPositionOffset = grabbedObjectTransform.position;
                grabRotationOffset = grabbedObjectTransform.rotation;
            }

            _currentGrabbedRigidbody.velocity = (transform.position - grabPositionOffset) / Time.fixedDeltaTime;
            _currentGrabbedRigidbody.maxAngularVelocity = 20f;

            var rotationDelta = _thisTransform.rotation * Quaternion.Inverse(grabRotationOffset);
            var eulerRotation = new Vector3(Mathf.DeltaAngle(0, rotationDelta.eulerAngles.x), Mathf.DeltaAngle(0, rotationDelta.eulerAngles.y),
                Mathf.DeltaAngle(0, rotationDelta.eulerAngles.z));
            eulerRotation *= 0.95f;
            eulerRotation *= Mathf.Deg2Rad;

            _currentGrabbedRigidbody.angularVelocity = eulerRotation / Time.fixedDeltaTime;
        }
    }
}