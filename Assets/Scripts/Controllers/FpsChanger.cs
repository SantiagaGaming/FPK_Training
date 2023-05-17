using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsChanger : MonoBehaviour
{
    private int _appFps = 60;
    private void Awake()
    {
        Application.targetFrameRate = _appFps;
       // Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
