using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SearchableObject : MonoBehaviour
{
    [SerializeField] protected string ObjectId;

    [SerializeField] protected GameObject Obj;

    public string GetObjectId => ObjectId;
    protected void Start()
    {
        SearchableObjectsHandler.Instance.AddSearchableObject(this);
    }

    public virtual void EnableObject(bool value)
    {
        if (Obj == null)
            return;
    }
}
