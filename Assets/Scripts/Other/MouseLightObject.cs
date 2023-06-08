using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLightObject : MonoBehaviour
{
    
    [SerializeField] private GameObject _light;
    [SerializeField] private RotateDoor _rotateDoor;


    private void OnEnable()
    {
        _rotateDoor.OnLightObjectOn += OnSwitchLightOn;
        _rotateDoor.OnLightObjectOff += OnSwitchLightOff;
    }
    private void OnDisable()
    {
        _rotateDoor.OnLightObjectOn -= OnSwitchLightOn;
        _rotateDoor.OnLightObjectOff -= OnSwitchLightOff;
    }

    private void OnSwitchLightOn()
    {
        _light.SetActive(true);
    }
    private void OnSwitchLightOff()
    {
        _light.SetActive(false);
    }
}
