using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHelper : MonoBehaviour
{
    [SerializeField] private Timer _timer;


    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private GameObject _helperImage;

    private const string HELPER_30 = "�� ���������� ������� �������� 30 �����";
    private const string HELPER_20 = "�� ���������� ������� �������� 20 �����";
    private const string HELPER_10 = "�� ���������� ������� �������� 10 �����";

    private bool _show = true;
    private bool _show2 = true;
    private void Start()
    {
        _timer.TimerHelperEvent += ShowHelper;
    }
    private void ShowHelper()
    {

        if (_timer.Time.Seconds == 10)
        {
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_30;

        }
        if (_timer.Time.Seconds == 60)
        {
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_20;

        }
        if (_timer.Time.Seconds == 100)
        {
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_10;

        }
    }
    private IEnumerator SetHelperText()
    {
        _helperImage.SetActive(true);
        yield return new WaitForSeconds(10);
        _helperImage.SetActive(false);
    }
}
