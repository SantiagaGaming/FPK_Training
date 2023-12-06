using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartParametr : MonoBehaviour
{
    public bool ShowInfoText = false;
    public static StartParametr Instance;
    public UnityAction Education;


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
            
            if (arg == "-lnr")
            {
               
                ShowInfoText = true;
                Education?.Invoke();
            }
           

        }
    }
}
