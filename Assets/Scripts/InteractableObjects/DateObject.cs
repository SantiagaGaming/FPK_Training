using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateObject : EnabableObject
{
    [SerializeField] private TextMeshProUGUI _dateText;
    private DateTime _date = DateTime.Now.AddMonths(3);
    private DateTime _dateOverdue = DateTime.Now.AddMonths(-3);
    protected override void Start()
    {
        base.Start();
        _dateText.text = _date.Date.ToString("dd/MM/yyyy");
    }
    public override void EnableObject(bool value)
    {
        Debug.Log("In " + value);
        if(!value)
            _dateText.text = _dateOverdue.Date.ToString("dd/MM/yyyy");
    }
}
