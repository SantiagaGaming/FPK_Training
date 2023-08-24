using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : BaseMenuButton
{
    [SerializeField] private GameObject _objectToShow;


    protected override void MenuButtonClick()
    {
        if(ObjectToHide!=null)
        ObjectToHide.SetActive(false);
        if (_objectToShow != null)
            _objectToShow.SetActive(true);
    }
}
