using System;
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
        return string.Format("{0:00}:{1:00}:{2:00}",Time.Hours, Time.Minutes, Time.Seconds);
    }
}
