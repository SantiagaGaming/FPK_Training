using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool Locked { get; set; } = true;

    private void Update()
    {
        Screen.lockCursor = Locked;    }
    //private void Awake()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
}
