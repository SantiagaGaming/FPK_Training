using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : BaseMenuButton
{
    [SerializeField] private GameObject _objectToShow;


    protected override void MenuButtonClick()
    {
        ObjectToHide.SetActive(false);
        _objectToShow.SetActive(true);
    }
}
