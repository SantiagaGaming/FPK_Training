using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionToClient _connectionToClient;
    
    private string _currentLocation = "none";
    private void Start()
    {
        _connectionToClient.ConnectionReadyEvent += ConnectionEstablished;
    }

    public void ConnectionEstablished()
    {
        _api.ConnectionEstablished(_currentLocation);
    }

   public void SetLocation(string location)
    {
        _currentLocation = location;
       
    }
}
