using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDoor : Door
{
    [SerializeField] private int _corner;
    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
            if (_corner < 0)
            {
                int y = 0;
                while (y >= _corner)
                {
                    transform.localEulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y--;

                }
            }
            else if(_corner > 0) 
            {
                int y = 0;
                while (y <= _corner)
                {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y++;

                }
            }
           
        }
        else
        {
            if (_corner < 0)
            {
                int y = 0;
                while (y >= _corner)
                {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
            }
            else if (_corner > 0)
            {
                int y = 0;
                while (y <= _corner)
                {
                    transform.localEulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y++;

                }
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }

}
