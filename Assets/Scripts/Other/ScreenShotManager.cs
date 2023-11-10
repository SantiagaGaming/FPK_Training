using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenShotManager : MonoBehaviour
{
    [SerializeField] private ScreenShot _screenShot;
    [SerializeField] private InputActionProperty keyboardAction;
    private void Start()
    {
        keyboardAction.action.performed += OnKeyPressed;
    }
    private void OnKeyPressed(InputAction.CallbackContext obj)
    {
        _screenShot.TakeHiResShot();
    }

}
