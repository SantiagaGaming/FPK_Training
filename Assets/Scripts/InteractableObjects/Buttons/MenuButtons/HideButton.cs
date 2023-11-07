using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButton : BaseMenuButton
{
    protected override void MenuButtonClick()
    {
        ObjectToHide.SetActive(false);
    }
}
