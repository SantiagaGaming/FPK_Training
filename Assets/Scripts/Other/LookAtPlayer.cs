using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera _ñamera;
    private void Start()
    {
        _ñamera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.LookAt(2 * transform.position - _ñamera.transform.position);
    }
}
