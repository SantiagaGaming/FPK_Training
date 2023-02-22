using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    [HideInInspector] public bool CanTeleport = true;

    [SerializeField] private Transform _menuPosition;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private EscController _escControler;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private ZoomController _zoomController;
    [SerializeField] private Image _knob;

    private Vector3 _currentPlayerPosition = new Vector3();

    private bool _changed= true;


    private void OnEnable()
    {
        _escControler.OnMenuEvent += OnEscClick;
    }
    private void OnDisable()
    {
        _escControler.OnMenuEvent -= OnEscClick;
    }
    private void OnEscClick()
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        if(_changed)
        {
            TeleportToMenu();
            _changed= false;
            _knob.enabled = false;
            _zoomController.ResetZoomCamera();
            _zoomController.CanZoom = false;
        }
        else
        {
            TeleportToPrevousLocation();
            _changed = true;
            _knob.enabled = true;
            _zoomController.CanZoom = true;
        }

    }
    private void TeleportToMenu()
    {
        _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 2.8f, _modeController.GetPlayerTransform().position.z);
        var playerInstance = Player.Instance;
        playerInstance.transform.rotation = Quaternion.Euler(0,0,0);
        playerInstance.TeleportTo(_menuPosition);
        playerInstance.CanMove = false;
        playerInstance.CursorLockMode = CursorLockMode.Locked;
        playerInstance.ForwardTo(transform);
    }

    private void TeleportToPrevousLocation()
    {
        var playerInstance = Player.Instance;
        playerInstance.ReleaseForwarding();
        playerInstance.TeleportTo(_currentPlayerPosition);
        playerInstance.CanMove = true;
        playerInstance.CursorLockMode = CursorLockMode.None;
    }


}