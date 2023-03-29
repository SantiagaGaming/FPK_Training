using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    [HideInInspector] public bool CanTeleport = true;

    [SerializeField] private View _view;
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private EscController _escControler;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private CheckListManager _checkListManager;
    [SerializeField] private Zoom _zoom;
    [SerializeField] private Image _knob;
    [SerializeField] private CursorManager _cursorManager;

    private Vector3 _currentPlayerPosition = new Vector3();

    private bool _changed= true;


    private void OnEnable()
    {
        _escControler.OnMenuEvent += OnEscClick;
        _view.OnBackButtonTap += OnEscClick;
    }
    private void OnDisable()
    {
        _escControler.OnMenuEvent -= OnEscClick;
        _view.OnBackButtonTap -= OnEscClick;
    }
    private void OnEscClick()
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        if(_changed)
        {
            _cursorManager.Locked = false;
            _checkListManager.Instantiate(SearchableObjectsHandler.Instance.CurrentRoom);
            TeleportToMenu();
            _changed= false;
            _zoom.ResetZoomCamera();
            _zoom.CanZoom = false;
        }
        else
        {
            TeleportToPrevousLocation();
            _changed = true;
            _cursorManager.Locked = true;
            _zoom.CanZoom = true;
        }
    }
    private void TeleportToMenu()
    {
        _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 1.5f, _modeController.GetPlayerTransform().position.z);
        var playerInstance = Player.Instance;
        playerInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
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
