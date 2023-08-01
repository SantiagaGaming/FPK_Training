using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwearDoor : Door
{
    [SerializeField] private Animator[] _animator;
    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        
        if (!value)
        {
            foreach (var item in _animator) { item.SetTrigger("Open"); }
            yield return new WaitForSeconds(1.5f);
            int x = 0;
            while (x <= 79)
            {
                transform.localEulerAngles += new Vector3(1, 0, 0);
                yield return new WaitForSeconds(0.01f);
                x++;
            }
        }

        
        else
        {
            int x = 79;
            while (x >= 0)
            {
                transform.localEulerAngles -= new Vector3(1, 0, 0);
                yield return new WaitForSeconds(0.01f);
                x--;
            }
          
            foreach (var item in _animator) { item.SetTrigger("Close"); }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }
}

