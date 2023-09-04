using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneExitTextInfo : MonoBehaviour
{
    private ObjectsTranslator _translator = new ObjectsTranslator();


    void Start()
    {
        SetZoneText();
    }

  public void SetZoneText()
    {
       
        foreach (var zone in InstanceHandler.Instance.ZoneTriggers)
        {
         
            if (!zone.IsVisited)
            {
                Debug.Log(zone);

            }
                
           
        }
    }
}
