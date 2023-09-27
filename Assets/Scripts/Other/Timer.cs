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
      
        if (second == 1800)
        {
            TimerHelperEvent?.Invoke();
            
        }
        if (second == 2400)
        {
            TimerHelperEvent?.Invoke();
        }
        if (second == 3000)
        {
            TimerHelperEvent?.Invoke();
        }
    }
    public string ReturnTime()
    {
       
        
        return string.Format("{0:00}:{1:00}", Time.Minutes, Time.Seconds);
        
    }
}
