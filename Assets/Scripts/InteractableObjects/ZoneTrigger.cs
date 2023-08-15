using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] private RoomName ZoneName;

    private void OnTriggerEnter(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        InstanceHandler.Instance.CurrentRoom = ZoneName;
    }
}
