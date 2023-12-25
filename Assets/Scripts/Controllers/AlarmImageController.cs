using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmImageController : MonoBehaviour
{
    [SerializeField] private Sprite _okImage;
    [SerializeField] private Sprite _notOkImage;
    [SerializeField] private Sprite _infoImage;
    [SerializeField] private Image _alarmImage;
    [SerializeField] private Image _alarmExitImage;
    

    public void SetAlarmImage(string imageName)
    {
        if(imageName == "0")
        {
            _alarmImage.sprite = _okImage;
        }
        else if (imageName == "1")
        {
            _alarmImage.sprite = _notOkImage;
        }
        else if (imageName == "2")
        {
            _alarmImage.sprite = _infoImage;
        }
    }
    public void SetAlarmExitImage(string imageName)
    {
        if (imageName == "0")
        {
            _alarmExitImage.sprite = _okImage;
        }
        else if (imageName == "1")
        {
            _alarmExitImage.sprite = _notOkImage;
        }
        else if (imageName == "2")
        {
            _alarmExitImage.sprite = _infoImage;
        }
    }

}
