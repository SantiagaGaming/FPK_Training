using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDoor : Door
{
    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
            Debug.Log("InUseDoor");
            int y = 0;
            while (y >= -55)
            {
                transform.localEulerAngles -= new Vector3(0, 1, 0);
                yield return new WaitForSeconds(0.01f);
                y--;
                Debug.Log("Inside" + y);
            }
            Debug.Log("OutUseDoor");
        }
        else
        {
            int y = -55;
            while (y <= 0)
            {
                transform.localEulerAngles += new Vector3(0, 1, 0);
                yield return new WaitForSeconds(0.01f);
                y++;
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }

}
