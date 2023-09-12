using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateObject : EnabableObject
{
    [SerializeField] private TextMeshProUGUI[] _dateText;
    [SerializeField] private TextMeshProUGUI _checkDateText;
    private DateTime _date = DateTime.Now.AddMonths(3);
    private DateTime _checkDate = DateTime.Now.AddMonths(-9);
    private DateTime _checkDateBad = DateTime.Now.AddMonths(-15);
    private DateTime _dateOverdue = DateTime.Now.AddMonths(-3);
    protected override void Start()
    {
        base.Start();
        if (_checkDateText != null)
        {
            _checkDateText.text = _checkDate.ToString("dd/MM/yyyy");
        }
        foreach (var item in _dateText)
            item.text = _date.Date.ToString("dd/MM/yyyy");
    }
    public override void EnableObject(bool value)
    {
        if (_checkDateText != null) { _checkDateText.text = _checkDateBad.ToString("dd/MM/yyyy"); }
        if (!value)
        {
            foreach (var item in _dateText)
                item.text = _dateOverdue.Date.ToString("dd/MM/yyyy");

        }
    }
}
