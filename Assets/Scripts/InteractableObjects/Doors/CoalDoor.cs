using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoalDoor : Door
{
    [SerializeField] private Animator[] _animator;
    [SerializeField] private Collider _collider;
    override protected IEnumerator UseDoor(bool value)
    {
        
        GetComponent<Collider>().enabled = false;
        
        if (!value)
        {
            _collider.enabled = false;
            foreach (var animator in _animator)
            {
                animator.SetTrigger("Open");
                yield return new WaitForSeconds(1.5f);
            }
            //yield return new WaitForSeconds(1.2f);


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
            _collider.enabled = true;
            int y = 70;
            while (y >= 0)
            {
                transform.localEulerAngles -= new Vector3(0, 1, 0);
                yield return new WaitForSeconds(0.01f);
                y--;
            }
            foreach (var animator in _animator)
            {
                animator.SetTrigger("Close");
                yield return new WaitForSeconds(1.5f);
            }

        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }
}
