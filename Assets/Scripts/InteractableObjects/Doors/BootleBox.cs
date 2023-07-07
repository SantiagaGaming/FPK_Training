using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BootleBox : Door
{
    protected override IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
            float x = 0f;
            while (x <= 60)
            {
                transform.localPosition += new Vector3(0.0025f, 0, 0);
                yield return new WaitForSeconds(0.0025f);
                x++;
            }
        }
        else
        {
            float x = 60;
            while (x >= 0)
            {
                transform.localPosition -= new Vector3(0.0025f, 0, 0);
                yield return new WaitForSeconds(0.0025f);
                x--;
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }
}
