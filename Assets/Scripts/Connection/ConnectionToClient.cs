using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AosSdk.Core.Utils.AosObjectBase;
using UnityEngine.Events;
using System.Threading;

[AosSdk.Core.Utils.AosObject(name: "�������")]
public class ConnectionToClient : AosObjectBase
{
    [SerializeField] private WebSocketWrapper _wrapper;
   
  
    [AosEvent(name: "����� � �����������")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    public UnityAction ConnectionReadyEvent;
    private void Start()
    {
        _wrapper.OnClientConnected += OnReadyToConnect;
    }
    public void OnReadyToConnect()
    {
        Thread.Sleep(2000);
        OnReadyToAction.Invoke("Ready to Action");
        ConnectionReadyEvent?.Invoke();         
        Debug.Log("Ready to Action");
       
    }
 
    
}
