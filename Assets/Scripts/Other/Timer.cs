using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityAction TimerHelperEvent;
    public TimeSpan Time { get; private set; }

    public void TimeChanger(double second)
    {
        Time = TimeSpan.FromSeconds(second);
    }
    public string ReturnTime()
    {
        if (Time.Seconds == 1800)
        {
            TimerHelperEvent?.Invoke();
        }
        if (Time.Seconds == 2400)
        {
            TimerHelperEvent?.Invoke();
        }
        if (Time.Seconds == 3000)
        {
            TimerHelperEvent?.Invoke();
        }
        return string.Format("{0:00}:{1:00}", Time.Minutes, Time.Seconds);
        
    }
}
