using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


[AosSdk.Core.Utils.AosObject(name: "������� ������")]
public class BreakObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    private SearchableObject _obj;
    private void Awake()
    {
        _obj = GetComponent<SearchableObject>();
        if (_obj == null)
        {
            Debug.Log("Searchable Object null" + gameObject.name);
        }
    }
    [AosAction(name: "������� ������")]
    public void Break()
    {
        Debug.Log("Broken!  "+ _obj.GetObjectId);
        _obj.EnableObject(false);
    }
    public void InvokeOnClick() => OnClickObject?.Invoke(ObjectId); 
}
