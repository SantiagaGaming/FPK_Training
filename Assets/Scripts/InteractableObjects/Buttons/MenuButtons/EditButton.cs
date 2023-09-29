using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : BaseMenuButton
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _submitButton;
    protected override void MenuButtonClick()
    {
        _submitButton.SetActive(true);
        ObjectToHide.SetActive(false);
        foreach (var button in _buttons)
        {
            button.enabled= true;
        }
        
    }

}
