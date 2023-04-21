using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoalDoor : Door
{
    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
           
            int y = 0;
            while (y <= 70)
            {
                transform.localEulerAngles += new Vector3(0, 1, 0);
                yield return new WaitForSeconds(0.01f);
                y++;
               
            }
           
        }
        else
        {
            int y = 70;
            while (y >= 0)
            {
                transform.localEulerAngles -= new Vector3(0, 1, 0);
                yield return new WaitForSeconds(0.01f);
                y--;
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }
}
