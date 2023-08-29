using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParametr : MonoBehaviour
{
    public bool ShowInfoText = false;
    public static StartParametr Instance;
    [SerializeField] private GameObject _obj;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        GetCommandLineArgs();
    }
    public void GetCommandLineArgs()
    {

        var commandLineArguments = Environment.GetCommandLineArgs();
        foreach (var arg in commandLineArguments)
        {
            Debug.Log(arg.ToString());
            if (arg == "-lnr")
            {
                _obj.SetActive(true);
                ShowInfoText = true;
            }

        }
    }
}
