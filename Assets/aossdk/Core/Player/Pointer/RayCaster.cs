using AosSdk.Core.Input;
using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using UnityEngine;

namespace AosSdk.Core.Player.Pointer
{
    public enum InteractHand
    {
        Right,
        Left,
        Desktop
    }

    public class RayCaster : MonoBehaviour
    {
        [SerializeField] private SharedInput sharedInput;
        [SerializeField] private InteractHand interactHand;
        [SerializeField] private Grabber grabber;

        private Collider _currentInteractAbleCollider;

        private IClickAble _currentClickAble;
        private IHoverAble _currentHoverAble;
        private IGrabbable _currentGrabbable;

        public bool TryGetInteractable(float interactDistance, out Vector3? hitPoint, out Vector3? hitNormal, out bool? isInteractable)
        {
            isInteractable = null;

            var (isGrabbed, isJustDropped) = grabber.HandleCurrentGrabbable(interactHand, _currentClickAble);

            if (isGrabbed || isJustDropped)
            {
                hitPoint = null;
                hitNormal = null;
                return false;
            }

            if (!Physics.Raycast(transform.position, transform.forward, out var hit, interactDistance, ~Physics.IgnoreRaycastLayer))
            {
                if (_currentHoverAble is {IsHoverable: true})
                {
                    _currentHoverAble.OnHoverOut(interactHand);
                }

                _currentInteractAbleCollider = null;
                _currentClickAble = null;
                _currentHoverAble = null;

                hitPoint = null;
                hitNormal = null;

                isInteractable = null;

                return false;
            }

            Debug.DrawLine(transform.position, hit.point, Color.magenta); // TODO remove on RC

            hitPoint = hit.point;
            hitNormal = hit.normal;

            try
            {
                if (hit.collider != _currentInteractAbleCollider)
                {
                    if (_currentHoverAble is {IsHoverable: true})
                    {
                        _currentHoverAble.OnHoverOut(interactHand);
                    }

                    _currentClickAble = hit.collider.gameObject.GetComponent<IClickAble>();
                    _currentHoverAble = hit.collider.gameObject.GetComponent<IHoverAble>();
                    _currentGrabbable = hit.collider.gameObject.GetComponent<IGrabbable>();

                    if (_currentHoverAble is {IsHoverable: true})
                    {
                        isInteractable = true;

                        _currentHoverAble.OnHoverIn(interactHand);
                    }
                }

                if (_currentClickAble is {IsClickable: true})
                {
                    isInteractable = true;

                    if (sharedInput.IsClicking)
                    {
                        _currentClickAble.OnClicked(interactHand);
                    }
                }

                if (_currentGrabbable is {IsGrabbable: true})
                {
                    isInteractable = true;

                    if (sharedInput.IsGrabbing)
                    {
                        grabber.TryGrabObject(interactHand, _currentGrabbable, hit.collider.gameObject);
                    }
                }

                if (_currentClickAble is {IsClickable: false} && _currentGrabbable is {IsGrabbable: false} && _currentHoverAble is {IsHoverable: false})
                {
                    isInteractable = false;
                }
            }
            finally
            {
                _currentInteractAbleCollider = hit.collider;
            }

            return true;
        }
    }
}