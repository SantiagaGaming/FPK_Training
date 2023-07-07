using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZolnikDoor : Door
{
    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
            int z = 0;
            while (z >= -165)
            {
                transform.localEulerAngles -= new Vector3(0, 0, 1);
                yield return new WaitForSeconds(0.01f);
                z--;
            }
        }
        else
        {
            int z = -165;
            while (z <= 0)
            {
                transform.localEulerAngles += new Vector3(0, 0, 1);
                yield return new WaitForSeconds(0.01f);
                z++;
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }
}
