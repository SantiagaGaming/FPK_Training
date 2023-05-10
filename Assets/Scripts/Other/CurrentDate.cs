using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentDate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _endText;
    [SerializeField] private TextMeshProUGUI _startText;
    private DateTime _endDate = DateTime.Now.AddMonths(6);
    private DateTime _startDate = DateTime.Now.AddMonths(-6);
    void Start()
    {
        _endText.text = _endDate.Date.ToString("dd/MM/yyyy");
        _startText.text = _startDate.Date.ToString("dd/MM/yyyy" + "  -");

    }

  
}
