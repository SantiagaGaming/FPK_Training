using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class EditButton : BaseMenuButton
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _submitButton;
    public Button[] Buttons => _buttons;
    protected override void MenuButtonClick()
    {
        _submitButton.SetActive(true);
        ObjectToHide.SetActive(false);
        foreach (var button in _buttons)
        {
            button.enabled = true;
            button.image.color = new Color(1, 1, 1, 1);
        }

    }

}
