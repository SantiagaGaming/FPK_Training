using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EscController : MonoBehaviour
{
    public UnityAction MenuTeleportEvent;

    [SerializeField] private API _api;
    [SerializeField] private InputActionProperty _menuAction;
    private void OnEnable()
    {
        if (_menuAction != null)
            _menuAction.action.performed += OnMenu;
    }
    private void OnDisable()
    {
        if (_menuAction != null)
            _menuAction.action.performed -= OnMenu;
    }
    private void OnMenu(InputAction.CallbackContext c)
    {
        MenuTeleportEvent?.Invoke();
        _api.OnMenuInvoke();
    }
}

