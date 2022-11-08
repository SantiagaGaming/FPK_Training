using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.DesktopPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class DesktopPlayer : MonoBehaviour, IPlayer
    {
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

        public bool CanMove { get; set; } = true;
        public bool CanRun { get; set; } = true;


        public Camera EventCamera
        {
            get => playerCamera;
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

                fadeControllerTransform.parent = playerCamera.transform;
                fadeControllerTransform.localPosition = new Vector3(0, 0, playerCamera.nearClipPlane + 0.01f);
            }
        }

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

        private Transform _forwardToTransform;

        private FadeController _fadeController;

        public void Init()
        {
            movementAction.action.performed += MovementActionActionOnPerformed;

            jumpAction.action.performed += JumpActionOnPerformed;

            runAction.action.performed += RunActionOnPerformed;
            runAction.action.canceled += RunActionOnCanceled;

            mouseXAction.action.performed += MouseXActionOnPerformed;
            mouseYAction.action.performed += MouseYActionOnPerformed;

            crouchAction.action.performed += CrouchActionOnPerformed;
            crouchAction.action.canceled += CrouchActionOnCanceled;

            _playerTransform = transform;

            _characterHeight = characterController.height;

            _playerCameraTransform = playerCamera.transform;
        }

        private void CrouchActionOnCanceled(InputAction.CallbackContext obj) => _isCrouching = false;

        private void CrouchActionOnPerformed(InputAction.CallbackContext obj) => _isCrouching = true;

        private void MouseYActionOnPerformed(InputAction.CallbackContext obj) => _mouseInput.y = obj.ReadValue<float>();

        private void MouseXActionOnPerformed(InputAction.CallbackContext obj) => _mouseInput.x = obj.ReadValue<float>();

        private void RunActionOnCanceled(InputAction.CallbackContext obj) => _isRunning = false;

        private void RunActionOnPerformed(InputAction.CallbackContext obj) => _isRunning = true;

        private void JumpActionOnPerformed(InputAction.CallbackContext obj) => _isJumping = true;

        private void MovementActionActionOnPerformed(InputAction.CallbackContext obj) => _horizontalInput = obj.ReadValue<Vector2>();

        private void OnDisable()
        {
            movementAction.action.performed -= MovementActionActionOnPerformed;
            jumpAction.action.performed -= JumpActionOnPerformed;
            runAction.action.performed -= RunActionOnPerformed;
            runAction.action.canceled -= RunActionOnCanceled;
            mouseXAction.action.performed -= MouseXActionOnPerformed;
            mouseYAction.action.performed -= MouseYActionOnPerformed;
            crouchAction.action.performed -= CrouchActionOnPerformed;
            crouchAction.action.canceled -= CrouchActionOnCanceled;
        }

        public void TeleportTo(Transform target)
        {
            var targetPosition = target.position;
            TeleportTo(targetPosition.x, targetPosition.y, targetPosition.z);
        }

        public void TeleportTo(float x, float y, float z)
        {
            _playerTransform.position =
                new Vector3(x, y + (characterController.height / 2 - characterController.center.y), z);
        }

        public void TeleportTo(string objectName)
        {
            var target = GameObject.Find(objectName)?.transform;

            if (target == null)
            {
                Player.Instance.ReportError(
                    $"Teleport to object failed, no object with name {objectName} found");
                return;
            }

            var targetPosition = target.position;
            TeleportTo(targetPosition.x, targetPosition.y, targetPosition.z);
        }

        public void ForwardTo(Transform target)
        {
            var targetPosition = target.position;

            var rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.eulerAngles = new Vector3(0, rotation.eulerAngles.y, 0);

            var cameraRotation = Quaternion.LookRotation(targetPosition - _playerCameraTransform.position);
            _playerCameraTransform.localEulerAngles = new Vector3(cameraRotation.eulerAngles.x, 0, 0);

            _forwardToTransform = target;
        }

        public void ReleaseForwarding()
        {
            if (!_forwardToTransform)
            {
                return;
            }

            var targetPosition = _forwardToTransform.position;

            var rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.eulerAngles = new Vector3(0, rotation.eulerAngles.y, 0);

            _rotationX = 0f;

            _isJumping = false;

            _isCrouching = false;

            _forwardToTransform = null;
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

        public void SetCrouchState(bool state)
        {
            if (state)
            {
                characterController.height = _characterHeight / 2;
                characterController.center = new Vector3(0, -_characterHeight / 4, 0);
            }
            else
            {
                characterController.height = _characterHeight;
                characterController.center = new Vector3(0, 0, 0);
            }
        }

        public void FadeIn(float speed, bool isInstant)
        {
            StartCoroutine(FadeController.FadeIn(speed, isInstant));
        }

        public void FadeOut(float speed, bool isInstant)
        {
            StartCoroutine(FadeController.FadeOut(speed, isInstant));
        }

        private void Update()
        {
            try
            {
                if (Launcher.Instance.SdkSettings.desktopMovementType == DesktopMovementType.Teleport)
                {
                    return;
                }

                var forward = transform.TransformDirection(Vector3.forward);
                var right = transform.TransformDirection(Vector3.right);

                var isRunning = _isRunning && CanRun;

                var speedMultiplier = isRunning ? Launcher.Instance.SdkSettings.runSpeed : Launcher.Instance.SdkSettings.walkSpeed;

                var curSpeedX = CanMove ? speedMultiplier * _horizontalInput.y : 0;
                var curSpeedY = CanMove ? speedMultiplier * _horizontalInput.x : 0;

                var movementDirectionY = _moveDirection.y;
                _moveDirection = forward * curSpeedX + right * curSpeedY;

                if (_isJumping && CanMove && characterController.isGrounded && !_isCrouching)
                {
                    _moveDirection.y = Launcher.Instance.SdkSettings.jumpSpeed;
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

                    SetCrouchState(true);
                }
                else
                {
                    SetCrouchState(false);
                }

                if (!characterController.isGrounded)
                {
                    _moveDirection.y -= Launcher.Instance.SdkSettings.gravity * Time.deltaTime;
                }

                if (!Physics.Raycast(transform.position + _moveDirection * characterController.skinWidth, -transform.up,
                        out var hit))
                {
                    return;
                }

                if (!hit.collider.CompareTag(Launcher.Instance.SdkSettings.walkableTag))
                {
                    return;
                }

                characterController.Move(_moveDirection * Time.deltaTime);
            }
            finally
            {
                if (Player.Instance.CursorLockMode != CursorLockMode.Locked)
                {
                    _rotationX += -_mouseInput.y * Launcher.Instance.SdkSettings.mouseLookSpeed;

                    _rotationX = Mathf.Clamp(_rotationX, -Launcher.Instance.SdkSettings.mouseLookXLimit, Launcher.Instance.SdkSettings.mouseLookXLimit);

                    _playerCameraTransform.localPosition =
                        new Vector3(0, characterController.center.y + characterController.height / 2, 0);
                    _playerCameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, _mouseInput.x * Launcher.Instance.SdkSettings.mouseLookSpeed, 0);
                }
            }
        }
    }
}