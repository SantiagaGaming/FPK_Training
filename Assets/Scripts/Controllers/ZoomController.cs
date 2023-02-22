using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ZoomController : MonoBehaviour
{
    [SerializeField] private InputActionProperty _wheelAction;
    [SerializeField] private Camera _playerCamera;

    public bool CanZoom = true;

    private float _zoom;
    private void OnEnable()
    {
        _wheelAction.action.performed += OnMouseWheel;
    }
    private void OnDisable()
    {
        _wheelAction.action.performed -= OnMouseWheel;
    } 
    public void ResetZoomCamera()
    {
            _playerCamera.fieldOfView = 60;
    }
     private void OnMouseWheel(InputAction.CallbackContext obj)
    {
        if(CanZoom)
        {
            _zoom = obj.ReadValue<float>();
            if (_zoom < 0)
                _playerCamera.fieldOfView = 60;
            else
                _playerCamera.fieldOfView = 15;
        }
    }
}
