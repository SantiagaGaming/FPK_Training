using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AosSdk.Core.Utils.AosObjectBase;
using UnityEngine.Events;
using System.Threading;
using Cysharp.Threading.Tasks;
using System;

[AosSdk.Core.Utils.AosObject(name: "Коннект")]
public class ConnectionToClient : AosObjectBase
{
    [SerializeField] private WebSocketWrapper _wrapper;
   
  
    [AosEvent(name: "Готов к подключению")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    public UnityAction ConnectionReadyEvent;
    private string _readyText = "Ready to Action";
    private void Start() => _wrapper.OnClientConnected += OnReadyToConnect;
    public async void OnReadyToConnect(IAsyncResult async)
    {
        await TryConnection(async);
    }

    private async UniTask TryConnection(IAsyncResult async)
    {
        await UniTask.WaitUntil(() => async.IsCompleted);
        OnReadyToAction.Invoke(_readyText);
        ConnectionReadyEvent?.Invoke();
       
    }


}
