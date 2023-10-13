using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoLocationButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty _infoText;
    
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
    private void OnShowInfoText(InputAction.CallbackContext c)
    {
       if(_enabled)
        {
            _infoPanel.SetActive(true);
            _enabled = false;
        }
        else
        {
            _infoPanel.SetActive(false);
            _enabled= true;
        }
        
        
        

    }
}
