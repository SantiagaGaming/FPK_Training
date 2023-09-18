using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateTimeNow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _timeText;

    private DateTime _currentDate = DateTime.Now;
    private TimeSpan Time;

    private void Start()
    {
        _dateText.text = _currentDate.ToString("dd/MM/yyyy");
        _timeText.text = _currentDate.Hour.ToString("D2")+ " : "+ _currentDate.Minute.ToString("D2");
        
    }
   
}
