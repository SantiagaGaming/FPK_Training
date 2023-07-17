using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreeKeyRotateDoor : Door
{
    

    [SerializeField] private bool _inside;
    [SerializeField] private bool _x;
    [SerializeField] private bool _down;
   


    override protected IEnumerator UseDoor(bool value)
    {
       
        
            DoorAction(true);

            if (!_inside)
            {

                if (!value)
                {
                    Debug.Log("5");
                    
                    yield return new WaitForSeconds(0.5f);
                    int y = 0;
                    while (y >= -90)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    DoorEvent?.Invoke();
                    
                }
                else
                {
                    Debug.Log("6");

                    DoorEventOpen?.Invoke();
                    yield return new WaitForSeconds(2.5f);
                    int y = -90;
                    while (y <= 0)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                   
                }
            }
            else
            {
                if (!value)
                {
                    Debug.Log("7");
                    
                    yield return new WaitForSeconds(1f);
                    int y = 0;
                    while (y <= 90)
                    {
                        transform.localEulerAngles -= new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y++;
                    }
                    
                }
                else
                {
                    Debug.Log("8");
                    

                    yield return new WaitForSeconds(0.5f);
                    int y = 90;
                    while (y >= 0)
                    {
                        transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                    
                }

            }
            DoorAction(false);
            if (open)
                open = false;
            else open = true;
        
    }
    
    
    protected override IEnumerator UseBrokenDoor(bool value)
    {

        DoorAction(true);

        if (!_inside)
        {
            if (!value)
            {
                Debug.Log("1");
                int y = -90;
                while (y <= 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
                DoorEvent?.Invoke();
                yield return new WaitForSeconds(2.2f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, -5, transform.rotation.z);
            }
            else
            {
                Debug.Log("2");
                yield return new WaitForSeconds(3f);
                int y = -5;
                while (y >= -90)
                {
                   
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
            }
        }
        else
        {

            if (!value)
            {
                Debug.Log("3");
                yield return new WaitForSeconds(1f);
                int y = 0;
                while (y <= 85)
                {
                    transform.localEulerAngles -= new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
            }
            else
            {
                Debug.Log(" 4");
                int y = 90;
                while (y >= 0)
                {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
            }
        }
        DoorAction(false);
        if (open)
            open = false;
        else open = true;
    }
}
