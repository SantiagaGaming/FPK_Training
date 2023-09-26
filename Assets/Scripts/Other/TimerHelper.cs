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
    private int _counter = 0;

    private const string HELPER_30 = "Ќа выполнение задани€ осталось   30 минут";
    private const string HELPER_20 = "Ќа выполнение задани€ осталось   20 минут";
    private const string HELPER_10 = "Ќа выполнение задани€ осталось   10 минут";

    private void Start()
    {
        _timer.TimerHelperEvent += ShowHelper;
    }
    private void ShowHelper()
    {

        if (_counter == 0)
        {
            Debug.Log("IN HELPER 0");
            _counter++;
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_30;

        }
        else if (_counter ==1)
        {
            _counter++;
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_20;
            Debug.Log("IN HELPER 1");

        }
        else if (_counter ==2)
        {
            _counter++;
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_10;
            Debug.Log("IN HELPER 2");

        }
    }
    private IEnumerator SetHelperText()
    {
        
        _helperImage.SetActive(true);
        yield return new WaitForSeconds(10);
        _helperImage.SetActive(false);
    }
}
