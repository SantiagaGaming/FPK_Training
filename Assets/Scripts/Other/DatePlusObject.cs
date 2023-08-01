using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DatePlusObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dateText;

    private DateTime _normDate = DateTime.Now.AddMonths(8);
    void Start()
    {
        _dateText.text = _normDate.Date.ToString("dd/MM/yyyy");
    }

}
