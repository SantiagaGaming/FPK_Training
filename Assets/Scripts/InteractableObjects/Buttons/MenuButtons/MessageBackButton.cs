using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBackButton : BaseMenuButton
{
    [SerializeField] private CameraChanger _cameraChanger;

    protected override void MenuButtonClick()
    {
        _cameraChanger.OnEscClick();
    }
}
