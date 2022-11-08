using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public class VrHeadCollider : MonoBehaviour
    {
        [SerializeField] private FadeController _fadeController;
        private Transform _thisTransform;

        private Collider _headCollider;

        private struct CurrentColliding
        {
            public Collider Collider;
            public Vector3 Position;
            public Quaternion Rotation;
        }

        private readonly List<CurrentColliding> _currentColliding = new List<CurrentColliding>();

        private void OnEnable()
        {
            _thisTransform = transform;
            _headCollider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            var colliderTransform = other.transform;

            var currentColliding = new CurrentColliding
            {
                Collider = other,
                Position = colliderTransform.position,
                Rotation = colliderTransform.rotation,
            };

            _currentColliding.Add(currentColliding);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            _currentColliding.Remove(_currentColliding.First(colliding => colliding.Collider == other));

            if (!_currentColliding.Any())
            {
                _fadeController.Fade(0);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            if (!_currentColliding.Any())
            {
                return;
            }

            var maxPenetration = 0f;

            foreach (var currentColliding in _currentColliding)
            {
                Physics.ComputePenetration(currentColliding.Collider, currentColliding.Position, currentColliding.Rotation, _headCollider, _thisTransform.position,
                    _thisTransform.rotation, out _, out var distance);
                maxPenetration = Mathf.Max(distance, maxPenetration);
            }

            _fadeController.Fade(Mathf.InverseLerp(0, 0.15f, maxPenetration));
        }

        private void LateUpdate()
        {
            if (!_currentColliding.Any())
            {
                _fadeController.Fade(0, isInstant: true);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.15f);
        }
    }
}