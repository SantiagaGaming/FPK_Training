using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Player.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.Player.DesktopPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class DesktopPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField] private AosSDKSettings sdkSettings;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private RayCaster rayCaster;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private InputActionProperty movementAction;
        [SerializeField] private InputActionProperty jumpAction;

        [SerializeField] private InputActionProperty runAction;

        [SerializeField] private InputActionProperty crouchAction;
        [SerializeField] private InputActionProperty mouseXAction;
        [SerializeField] private InputActionProperty mouseYAction;

        [SerializeField] private Grabber grabber;

        public bool CanRun { get; set; } = true; // TODO Move to IPlayer
        public bool CanMove { get; set; } = true;

        private Transform _playerTransform;

        private Vector3 _moveDirection = Vector3.zero;
        private float _rotationX;

        private Vector2 _horizontalInput;
        private Vector2 _mouseInput;
        private bool _isJumping;

        private bool _isRunning;
        private bool _isCrouching;

        private float _characterHeight;

        private Transform _playerCameraTransform;

        private void OnEnable()
        {
            // TODO unsubscribe
            movementAction.action.performed += context => _horizontalInput = context.ReadValue<Vector2>();

            jumpAction.action.performed += _ => _isJumping = true;

            runAction.action.performed += _ => _isRunning = true;
            runAction.action.canceled += _ => _isRunning = false;

            mouseXAction.action.performed += context => _mouseInput.x = context.ReadValue<float>();

            mouseYAction.action.performed += context => _mouseInput.y = context.ReadValue<float>();

            crouchAction.action.performed += _ => _isCrouching = true;

            crouchAction.action.canceled += _ => _isCrouching = false;

            _playerTransform = transform;

            _characterHeight = characterController.height;

            _playerCameraTransform = playerCamera.transform;
        }

        public void TeleportTo(Transform target)
        {
            characterController.enabled = false;
            _playerTransform.position = target.position;
            _playerTransform.rotation = target.rotation;
            characterController.enabled = true;
        }

        public void TeleportTo(float x, float y, float z)
        {
            _playerTransform.position = new Vector3(x, y, z);
        }

        public void TeleportTo(string objectName)
        {
            var target = GameObject.Find(objectName)?.transform;

            if (!target)
            {
                RuntimeData.Instance.CurrentPlayer.ReportError($"Teleport to object failed, no object with name {objectName} found");
                return;
            }

            _playerTransform.position = target.position;
            _playerTransform.rotation = target.rotation;
        }

        public void EnableCamera(bool value)
        {
            playerCamera.enabled = value;
        }

        public void EnableRayCaster(bool value)
        {
            rayCaster.enabled = value;
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

            grabber.TryGrabObject(InteractHand.Desktop, grabbable, gameObjectToGrab);
        }

        public void DropObject(int hand)
        {
            grabber.DropCurrentGrabbedObject();
        }

        private void Update()
        {
            try
            {
                var forward = transform.TransformDirection(Vector3.forward);
                var right = transform.TransformDirection(Vector3.right);

                var isRunning = _isRunning && CanRun;

                var speedMultiplier = isRunning ? sdkSettings.runSpeed : sdkSettings.walkSpeed;

                var curSpeedX = CanMove ? speedMultiplier * _horizontalInput.y : 0;
                var curSpeedY = CanMove ? speedMultiplier * _horizontalInput.x : 0;

                var movementDirectionY = _moveDirection.y;
                _moveDirection = forward * curSpeedX + right * curSpeedY;

                if (_isJumping && CanMove && characterController.isGrounded && !_isCrouching)
                {
                    _moveDirection.y = sdkSettings.jumpSpeed;
                    _isJumping = false;
                }
                else
                {
                    _moveDirection.y = movementDirectionY;
                }

                if (_isCrouching && characterController.isGrounded)
                {
                    if (_isJumping)
                    {
                        _isJumping = false;
                    }

                    characterController.height = _characterHeight / 2;
                    characterController.center = new Vector3(0, -_characterHeight / 4, 0);
                }
                else
                {
                    characterController.height = _characterHeight;
                    characterController.center = new Vector3(0, 0, 0);
                }

                if (!characterController.isGrounded)
                {
                    _moveDirection.y -= sdkSettings.gravity * Time.deltaTime;
                }

                if (!Physics.Raycast(transform.position + _moveDirection * characterController.skinWidth, -transform.up, out var hit))
                {
                    return;
                }

                if (!hit.collider.CompareTag(sdkSettings.walkableTag))
                {
                    return;
                }

                characterController.Move(_moveDirection * Time.deltaTime);
            }
            finally
            {
                _rotationX += -_mouseInput.y * sdkSettings.mouseLookSpeed;

                _rotationX = Mathf.Clamp(_rotationX, -sdkSettings.mouseLookXLimit, sdkSettings.mouseLookXLimit);
                _playerCameraTransform.localPosition = new Vector3(0, characterController.center.y + characterController.height / 2, 0);
                _playerCameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, _mouseInput.x * sdkSettings.mouseLookSpeed, 0);
            }
        }
    }
}