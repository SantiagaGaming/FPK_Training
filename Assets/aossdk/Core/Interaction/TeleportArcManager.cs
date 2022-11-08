using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.Interaction
{
    [RequireComponent(typeof(LineRenderer))]
    public class TeleportArcManager : MonoBehaviour
    {
        [SerializeField] private LayerMask excludeLayers;
        [SerializeField] private Gradient validTeleportGradient;
        [SerializeField] private Gradient invalidTeleportGradient;

        private const int MaxArcPointCount = 30;
        private const float VertexDelta = 0.08f;

        private LineRenderer _arcRenderer; 

        private Vector3 _currentArcPointVelocity;
        private Vector3 _arcHighestPoint;
        private Vector3 _arcLastPoint;
        private Vector3 _previousPointPosition;

        private int _arcPointsCalculated;
        
        private Transform _thisTransform;

        private bool _groundDetected;
        private bool _teleportIsActive;

        public TeleportRaycastData RaycastData;

        public void ToggleDisplay(bool active)
        {
            _arcRenderer.enabled = active;
            _teleportIsActive = active;
        }
    
        private void OnEnable()
        {
            _arcRenderer = GetComponent<LineRenderer>();
            _arcRenderer.enabled = false;
            _thisTransform = transform;
        }

        private void LateUpdate()
        {
            if (!_teleportIsActive)
            {
                return;
            }
            
            UpdateArc();
        }

        private void UpdateArc()
        {
            _arcHighestPoint = Vector3.zero;
            _arcLastPoint = Vector3.zero;
            _groundDetected = false;
            
            var origin = _thisTransform.position;
            var forward = _thisTransform.forward;
            
            _previousPointPosition = origin;
            _arcPointsCalculated = 0;
            
            RaycastData.IsTeleportValid = false;
            RaycastData.TeleportNormal = null;
            RaycastData.TeleportPosition = null;
            
            _arcRenderer.colorGradient = invalidTeleportGradient;
            _arcRenderer.positionCount = 2;
            
            _arcLastPoint = origin + forward;
            
            _currentArcPointVelocity = forward * Launcher.Instance.SdkSettings.maxTeleportRadius;

            while (!_groundDetected && _arcPointsCalculated <= MaxArcPointCount)
            {
                var newPosition = _previousPointPosition + _currentArcPointVelocity * VertexDelta + Physics.gravity * (0.5f * Mathf.Pow(VertexDelta, 2));

                if (newPosition.y < _previousPointPosition.y && _arcHighestPoint == Vector3.zero)
                {
                    _arcHighestPoint = newPosition;
                }

                _currentArcPointVelocity += Physics.gravity * VertexDelta;
                
                _arcPointsCalculated++;

                if (Physics.Linecast(_previousPointPosition, newPosition, out var hit, ~excludeLayers))
                {
                    _groundDetected = true;
                    _arcLastPoint = hit.point;
                    _arcRenderer.positionCount = MaxArcPointCount;
                    
                    if (hit.collider.CompareTag(Launcher.Instance.SdkSettings.walkableTag))
                    {
                        RaycastData.TeleportPosition = hit.point;
                        RaycastData.TeleportNormal = hit.normal;
                        RaycastData.IsTeleportValid = true;
                        _arcRenderer.colorGradient = validTeleportGradient;
                    }
                    
                    break;
                }
                
                _previousPointPosition = newPosition;
            }

            if (_arcHighestPoint == Vector3.zero)
            {
                _arcHighestPoint = origin;
            }

            var t = 0f;
            for (var i = 0; i < _arcRenderer.positionCount; i++)
            {
                _arcRenderer.SetPosition(i, (1 - t) * (1 - t) * origin + 2 * (1 - t) * t * _arcHighestPoint + t * t * _arcLastPoint);
                t += 1 / (float)_arcRenderer.positionCount;
            }
        }
    
        public struct TeleportRaycastData
        {
            public Vector3? TeleportPosition;
            public Vector3? TeleportNormal;
            public bool IsTeleportValid;
        }
    }
}