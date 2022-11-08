using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.VRPlayer.Hands
{
    [RequireComponent(typeof(Animator))]
    public class HandAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputActionProperty teleportActivateAction;
        [SerializeField] private InputActionProperty triggerAction;

        private static readonly int StartTeleport = Animator.StringToHash("startTeleport");
        private static readonly int EndTeleport = Animator.StringToHash("endTeleport");

        private static readonly int StartUse = Animator.StringToHash("startUse");
        private static readonly int EndUse = Animator.StringToHash("endUse");

        private static readonly int StartPoint = Animator.StringToHash("startPoint");
        private static readonly int EndPoint = Animator.StringToHash("endPoint");

        private TeleportAnimationHandler _teleportAnimationHandler;
        private UseAnimationHandler _useAnimationHandler;
        private PointAnimationHandler _pointAnimationHandler;

        private void Start()
        {
            _teleportAnimationHandler = animator.GetBehaviour<TeleportAnimationHandler>();
            _useAnimationHandler = animator.GetBehaviour<UseAnimationHandler>();
            _pointAnimationHandler = animator.GetBehaviour<PointAnimationHandler>();
        }

        public void StopPerformingPoint()
        {
            if (!_pointAnimationHandler.IsInPointState || animator.IsInTransition(0))
            {
                return;
            }

            animator.SetTrigger(EndPoint);
        }

        public void PerformPoint()
        {
            if (_useAnimationHandler.IsInUseState || _teleportAnimationHandler.IsInTeleportState || _pointAnimationHandler.IsInPointState)
            {
                return;
            }

            animator.SetTrigger(StartPoint);
        }

        private void OnEnable()
        {
            teleportActivateAction.action.performed += TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled += TeleportationActivateActionOnCancelled;

            triggerAction.action.performed += TriggerActionPerformed;
            triggerAction.action.canceled += TriggerActionCancelled;
        }

        private void OnDisable()
        {
            teleportActivateAction.action.performed -= TeleportationActivateActionOnPerformed;
            teleportActivateAction.action.canceled -= TeleportationActivateActionOnCancelled;

            triggerAction.action.performed -= TriggerActionPerformed;
            triggerAction.action.canceled -= TriggerActionCancelled;
        }

        private void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(StartTeleport);
        }

        private void TeleportationActivateActionOnCancelled(InputAction.CallbackContext obj)
        {
            if (!_teleportAnimationHandler.IsInTeleportState) // fix: snap turn cancel event triggers this method
            {
                return;
            }

            animator.SetTrigger(EndTeleport);
        }

        private void TriggerActionPerformed(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(StartUse);
        }

        private void TriggerActionCancelled(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(EndUse);
        }
    }
}