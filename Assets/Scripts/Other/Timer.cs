using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TimeSpan _time;

    public void TimeChanger(double second)
    {
        _time = TimeSpan.FromSeconds(second);
    }
    public string ReturnTime()
    {
        if (_time.Seconds > 10)
        {
            Debug.Log("Подсказка");
        }
        return string.Format("{0:00}:{1:00}", _time.Minutes, _time.Seconds);
        
    }
}
