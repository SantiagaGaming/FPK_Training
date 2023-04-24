using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Door door))
        {
            
            var tempDoor = GetComponent<Door>();
            if (tempDoor == null)
                return;
            tempDoor.UseDoorByCollide(true);
                
        }
        
    }
}
