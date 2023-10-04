using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera _�amera;
    private void Start()
    {
        _�amera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        transform.LookAt(2 * transform.position - _�amera.transform.position);
    }
}
