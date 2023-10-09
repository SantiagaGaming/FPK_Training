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
    WC1,
    CoupeSleep,
    CoupeOfficial,
    VestibuleWorking,
    VestibuleNonWorking,
    WagonOutside,
    CoupeNumber9,
    CoupeNumber2,
    WC2
}

public abstract class SearchableObject : MonoBehaviour
{
    [SerializeField] protected string ObjectId;

    [SerializeField] protected GameObject Obj;
    [SerializeField] protected RoomName RoomName;
    [SerializeField] protected GameObject ClueObject;
    public RoomName GetRoomName => RoomName;

    public string GetObjectId => ObjectId;
    protected virtual void Start()
    {
    }

    public virtual void EnableObject(bool value)
    {
        if (Obj == null)
            return;
    }
    public void ShowClueObject()
    {
        
        ClueObject.SetActive(true);
    }
}
