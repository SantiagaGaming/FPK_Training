using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [SerializeField] private InputActionProperty _wheelAction;
    [SerializeField] private Camera _playerCamera;
    private float _zoomValue;

    public bool CanZoom = true;

    private float _zoom;
    private void Start()
    {
        _zoomValue = _playerCamera.fieldOfView;
    }
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
        if (!CanZoom)
            return;
            _zoom = obj.ReadValue<float>();
            if (_zoom > 0)
        {
            _zoomValue -= 15;
            if (_zoomValue < 15)
                _zoomValue = 15;
        }

        else
        {
            _zoomValue += 15;
            if (_zoomValue > 60)
                _zoomValue = 60;
        }
       
        _playerCamera.fieldOfView = _zoomValue;
    }
}
