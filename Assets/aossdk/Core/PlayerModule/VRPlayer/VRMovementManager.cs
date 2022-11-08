using System;
using AosSdk.Core.Interaction;
using AosSdk.Core.Utils;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public sealed class VRMovementManager : MovementManager
    {
        [SerializeField] private MovementManager _anotherHandMovementManager;
        [SerializeField] private XROrigin _xrOrigin;
        [SerializeField] private CharacterController _characterController;

        private Vector3 _verticalVelocity;

        protected override void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (_anotherHandMovementManager && _anotherHandMovementManager.IsMovementInProgress ||
                !Player.Instance.CanMove)
            {
                return;
            }

            IsMovementInProgress = true;
            teleportArcManager.ToggleDisplay(true);
        }

        private void Update()
        {
            if (!Player.Instance.CanMove || !IsVRLocomotion())
            {
                return;
            }

            var desiredMove = new Vector3();

            try
            {
                var input = TeleportActivateAction.reference.action.ReadValue<Vector2>();

                desiredMove = ComputeDesiredMove(input);

                if (!Physics.Raycast(transform.position + desiredMove * _characterController.skinWidth, -transform.up,
                        out var hit))
                {
                    return;
                }

                if (!hit.collider.CompareTag(Launcher.Instance.SdkSettings.walkableTag))
                {
                    desiredMove = Vector3.zero;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                MoveRig(desiredMove);
            }
        }

        private Vector3 ComputeDesiredMove(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                return Vector3.zero;
            }

            var inputMove = Vector3.ClampMagnitude(new Vector3(input.x, 0f, input.y), 1f);

            var originTransform = _xrOrigin.Origin.transform;
            var originUp = originTransform.up;

            var forwardSourceTransform = _xrOrigin.Camera.transform;
            var inputForwardInWorldSpace = forwardSourceTransform.forward;
            if (Mathf.Approximately(Mathf.Abs(Vector3.Dot(inputForwardInWorldSpace, originUp)), 1f))
            {
                inputForwardInWorldSpace = -forwardSourceTransform.up;
            }

            var inputForwardProjectedInWorldSpace = Vector3.ProjectOnPlane(inputForwardInWorldSpace, originUp);
            var forwardRotation = Quaternion.FromToRotation(originTransform.forward, inputForwardProjectedInWorldSpace);

            var translationInRigSpace = forwardRotation * inputMove * (Launcher.Instance.SdkSettings.locomotionMovementSpeed * Time.deltaTime);
            var translationInWorldSpace = originTransform.TransformDirection(translationInRigSpace);

            return translationInWorldSpace;
        }

        private void MoveRig(Vector3 translationInWorldSpace)
        {
            var motion = translationInWorldSpace;

             if (_characterController.isGrounded)
             {
                 _verticalVelocity = Vector3.zero;
             }
             else
             {
                 _verticalVelocity += Physics.gravity * Time.deltaTime;
             }

            motion += _verticalVelocity * Time.deltaTime;

            _characterController.Move(motion);
        }
    }
}