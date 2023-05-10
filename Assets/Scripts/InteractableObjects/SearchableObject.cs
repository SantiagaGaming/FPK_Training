using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoomName 
{ 
    None,
    Kotel,
    Koridor,
    SmallKoridor,
    ObliqueKoridor,
    WC,
    CoupeSleep,
    CoupeOfficial,
    VestibuleWorking,
    VestibuleNonWorking,
    WagonOutside,
    CoupeNumber9,
    CoupeNumber2
}

public abstract class SearchableObject : MonoBehaviour
{
    [SerializeField] protected string ObjectId;

    [SerializeField] protected GameObject Obj;
    [SerializeField] protected RoomName RoomName;
    public RoomName GetRoomName => RoomName;

    public string GetObjectId => ObjectId;
    protected virtual void Start()
    {
        SearchableObjectsHandler.Instance.AddSearchableObject(this);
    }

    public virtual void EnableObject(bool value)
    {
        if (Obj == null)
            return;
    }
}
