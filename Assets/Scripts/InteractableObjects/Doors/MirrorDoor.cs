using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDoor : Door
{
    [SerializeField] private int _corner;
    [SerializeField] private Animator _animator;

    override protected IEnumerator UseDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (!value)
        {
            if (_corner < 0)
            {
                _animator.SetTrigger("Open");
                yield return new WaitForSeconds(1.5f);
                Debug.Log("1");
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
                _animator.SetTrigger("Open");
                yield return new WaitForSeconds(1.5f);
                Debug.Log("2");
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
                Debug.Log("3");
                int y = 0;
                while (y >= _corner)
                {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
                _animator.SetTrigger("Close");
            }
            else if (_corner > 0)
            {
                Debug.Log("4");
                int y = 0;
                while (y <= _corner)
                {
                    transform.localEulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y++;

                }
                _animator.SetTrigger("Close");
            }
        }
        GetComponent<Collider>().enabled = true;
        if (open)
            open = false;
        else open = true;
    }

}
