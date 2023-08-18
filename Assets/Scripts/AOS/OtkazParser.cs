using AosSdk.Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class OtkazParser : MonoBehaviour
{
    [SerializeField] private API _api;

    private void Start()
    {
        CheckListHolder.AddNewOtazList += OnSendOtazObject;
    }
    private void OnSendOtazObject(OtkazModel otkazModel)
    {
        var jsonObjectToSend =  JsonConvert.SerializeObject(otkazModel);
        if(jsonObjectToSend!=null)
            _api.OnReasonInvoke(jsonObjectToSend.ToLower());
       
    }
}
