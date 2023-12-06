using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoLocationButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty _infoText;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _keyboardPanel;
    [SerializeField] private GameObject[] _infoObj;
    private bool _enabled = true;
    private bool _can = false;


    private void Start()
    {
        StartParametr.Instance.Education += ShowImage;
    }
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
        if(_can)
        {
            if (_enabled)
            {
                _infoPanel.SetActive(true);
                _enabled = false;
                _keyboardPanel.SetActive(false);
            }
            else
            {
                _infoPanel.SetActive(false);
                _enabled = true;
            }
        }
        

    }
    private void ShowImage()
    {
        foreach (var item in _infoObj)
        {
            item.SetActive(true);
            _can = true;
        }
    }
}
