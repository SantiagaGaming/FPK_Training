using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboarInfoButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty _infoText;

    [SerializeField] private GameObject _keyboardPanel;
    [SerializeField] private GameObject _infoPanel;
    private bool _enabled = true;



    private void OnEnable()
    {
        _infoText.action.performed += OnShowInfoText;
    }
    private void OnDisable()
    {
        _infoText.action.performed -= OnShowInfoText;
    }
    public void OnShowInfoText(InputAction.CallbackContext c)
    {
        if (_enabled)
        {
            _keyboardPanel.SetActive(true);
            _enabled = false;
            _infoPanel.SetActive(false);
        }
        else
        {
            _keyboardPanel.SetActive(false);
            _enabled = true;
        }

    }


}
