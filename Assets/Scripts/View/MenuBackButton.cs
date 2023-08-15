using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackButton : BaseMenuButton
{
    [SerializeField] private View _view;
    protected override void MenuButtonClick()
    {
        _view.InvokeBackButtonTap();
    }
}
