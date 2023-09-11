using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DatePlusObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _checkDateText;

    private DateTime _normDate = DateTime.Now.AddMonths(8);
    private DateTime _normDate2 = DateTime.Now.AddMonths(-4);
    void Start()
    {
        _dateText.text = _normDate.Date.ToString("dd/MM/yyyy");
        _checkDateText.text = _normDate2.Date.ToString("dd/MM/yyyy");
    }

}
