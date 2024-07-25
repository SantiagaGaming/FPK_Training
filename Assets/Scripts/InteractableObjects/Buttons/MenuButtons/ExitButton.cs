using System;
using UnityEngine;

public class ExitButton :BaseMenuButton
{
    [SerializeField] private API _api;

    protected override void MenuButtonClick()
    {
      
        try 
        {
            _api.OnInvokeNavAction("exit");
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            Application.Quit();
        }        
    }
}