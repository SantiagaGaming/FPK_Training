using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHelper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerMinuteText;

    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private GameObject _helperImage;
    [HideInInspector] public bool StartGame = false;

    private const string HELPER_30 = "Ќа выполнение задани€ осталось 30 минут";
    private const string HELPER_20 = "Ќа выполнение задани€ осталось 20 минут";
    private float _timerMinute = 59;
    private float _timerSecond = 60;

    private bool _show = true;
    private bool _show2 = true;

    private void Start()
    {

    }
    private void Update()
    {
        if(StartGame)
        {
            StartTimer();
        }
    }
    private void StartTimer()
    {
        _timerSecond -= Time.timeScale * Time.deltaTime;
        if (_timerSecond <= 0)
        {
            _timerMinute--;
            _timerSecond = 60;
        }
        _timerMinuteText.text = _timerMinute.ToString() + ":" + ((int)_timerSecond % 60).ToString("D2");
        if (_timerMinute == 29 && _show)
        {
            _show = false;
            ShowHelper(29);
        }
        if (_timerMinute == 19 && _show2)
        {
            _show2 = false;
            ShowHelper(19);
        }
    }
    private void ShowHelper(int time)
    {
        
        if (time ==29)
        {
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_30;
           
        }
        if (time== 18)
        {
            StartCoroutine(SetHelperText());
            _helperText.text = HELPER_20;
            
        }
    }
    private IEnumerator SetHelperText()
    {
        _helperImage.SetActive(true);
        yield return new WaitForSeconds(10);
        _helperImage.SetActive(false);
    }
}
