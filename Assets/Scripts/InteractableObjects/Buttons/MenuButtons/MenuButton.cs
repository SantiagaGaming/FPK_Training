using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MenuButton : BaseMenuButton
{
    public UnityAction ExitTextButtonEvent;

    [SerializeField] private GameObject _objectToShow;
    [SerializeField] private GameObject _infoToShow;
    

    public bool ExitTextButton;
    public bool InfoButton;


    protected override void MenuButtonClick()
    {
        if(ObjectToHide!=null)
        ObjectToHide.SetActive(false);
        if (_objectToShow != null)
            _objectToShow.SetActive(true);
        if (ExitTextButton)
        {
            ExitTextButtonEvent?.Invoke();
        }
        if (InfoButton && StartParametr.Instance.ShowInfoText)
        {
            if(_infoToShow != null) 
                _infoToShow.SetActive(true);
            
        }
    }
}
