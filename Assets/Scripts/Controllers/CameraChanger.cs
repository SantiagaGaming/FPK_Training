using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private EscController _escControler;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private Image _knob;
    private bool _changed= true;
    private Vector3 _currentPlayerPosition = new Vector3();
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
        _cameraFadeIn.FadeStart = true;
        if(_changed)
        {
            TeleportToMenu();
            _changed= false;
            _knob.enabled = false;
        }
        else
        {
            TeleportToPrevousLocation();
            _changed = true;
            _knob.enabled = true;
        }

    }
    private void TeleportToMenu()
    {
        _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 4.2f, _modeController.GetPlayerTransform().position.z);
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
