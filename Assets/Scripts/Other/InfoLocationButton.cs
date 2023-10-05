using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoLocationButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty _infoText;
    [SerializeField] private CameraChanger _cameraChanger;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _mainPanel;
    

    private void OnEnable()
    {
        _infoText.action.performed += OnShowInfoText;
    }
    private void OnDisable()
    {
        _infoText.action.performed -= OnShowInfoText;
    }
    private void OnShowInfoText(InputAction.CallbackContext c)
    {
        if (!StartParametr.Instance.ShowInfoText)
            return;
        _cameraChanger.OnEscClick();
        _infoPanel.SetActive(true);
        _mainPanel.SetActive(false);

    }
}
