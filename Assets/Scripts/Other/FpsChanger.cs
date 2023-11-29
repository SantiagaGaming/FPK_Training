using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsChanger : MonoBehaviour
{
    private int _appFps = 60;
    //private float _fps;
    //[SerializeField] private TextMeshProUGUI _fpsText;
    private void Awake()
    {
        Application.targetFrameRate = _appFps;
       // Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
    //private void Start()
    //{
    //    StartCoroutine(SetText());
    //}
    //private void Update()
    //{
    //    _fps = 1.0f / Time.deltaTime;
       
    //}
    //private  IEnumerator SetText()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1);
    //        _fpsText.text = _fps.ToString();
    //    }
    //}
}
