using AosSdk.Core.Input;
using AosSdk.Core.Player.VRPlayer.Hands;
using UnityEngine;

namespace AosSdk.Core.Player.Pointer
{
    [RequireComponent(typeof(LineRenderer))]
    public class VrPointer : Pointer
    {
        [SerializeField] private Transform reticle;
        [SerializeField] private HandAnimator handAnimator;

        private LineRenderer _lineRenderer;

        private PointerState PointerState
        {
            set
            {
                if (value == CurrentState)
                {
                    return;
                }

                _lineRenderer.enabled = value != PointerState.Default;
                reticle.gameObject.SetActive(value != PointerState.Default);

                _lineRenderer.endColor = GetPointerColor(value);
                CurrentState = value;
            }
        }

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2;
            _lineRenderer.enabled = false;
        }

        private void Update()
        {
            if (!raycaster.TryGetInteractable(sdkSettings.desktopInteractDistance, out var hitPoint, out var hitNormal, out var isInteractable) ||
                isInteractable == null) // TODO Test if this works properly (raycast to ground shouldn't draw ray)
            {
                PointerState = PointerState.Default;
                
                if (handAnimator == null)
                {
                    return;
                }
                
                handAnimator.StopPerformingPoint();
                return;
            }

            PointerState = (bool) isInteractable ? PointerState.Hovered : PointerState.Disabled;

            if (hitPoint == null || hitNormal == null)
            {
                return;
            }

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, (Vector3) hitPoint);

            reticle.position = (Vector3) hitPoint;
            reticle.up = (Vector3) hitNormal;

            if (handAnimator == null)
            {
                return;
            }

            handAnimator.PerformPont();
        }
    }
}