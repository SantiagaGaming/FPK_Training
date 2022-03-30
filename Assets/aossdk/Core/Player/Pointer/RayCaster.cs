using AosSdk.Core.Input;
using AosSdk.Core.Interfaces;
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

        private Collider _currentInteractAbleCollider;
        private IClickAble _currentClickAble;
        private IHoverAble _currentHoverAble;

        public bool TryGetInteractable(float interactDistance, out Vector3? hitPoint, out Vector3? hitNormal, out bool? isInteractable)
        {
            isInteractable = null;
            
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

                    if (_currentHoverAble is {IsHoverable: true})
                    {
                        isInteractable = true;
                        _currentHoverAble.OnHoverIn(interactHand);
                    }
                }

                switch (_currentClickAble)
                {
                    case {IsClickable: true}:
                    {
                        isInteractable = true;

                        if (!sharedInput.IsClicking)
                        {
                            return true;
                        }

                        _currentClickAble.OnClicked(interactHand);

                        return true;
                    }
                    case {IsClickable: false} when _currentHoverAble is {IsHoverable: false}:
                        isInteractable = false;
                        break;
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