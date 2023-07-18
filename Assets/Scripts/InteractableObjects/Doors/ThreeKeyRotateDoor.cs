using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThreeKeyRotateDoor : Door
{
    

    [SerializeField] private bool _inside;
    [SerializeField] private bool _x;
    [SerializeField] private bool _down;
    [SerializeField] private float _doorParametrStart; // начальные кординаты при отказе
    [SerializeField] private float _doorParametrEnd; // закрытие  при отказе
    [SerializeField] private float _finishBrokenParametr; // открытие двери в конце для отказа
    [SerializeField] private float _closePatametr; // начало закрытия  
    [SerializeField] private float _closePatametr2; // конец закрытия
    
   


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
                    yield return new WaitForSeconds(3f);
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
                DoorEvent?.Invoke();

            }
                else
                {
                    Debug.Log("8");

                DoorEventOpen?.Invoke();
                yield return new WaitForSeconds(2.5f);
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
                float y = _closePatametr;     // -90  -42
                while (y <= _closePatametr2)    // 0  45
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
                DoorEvent?.Invoke();
                yield return new WaitForSeconds(2.3f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, _finishBrokenParametr, transform.rotation.z);
            }
            else
            {
                Debug.Log("2");
                DoorEventOpen?.Invoke();
                yield return new WaitForSeconds(2.5f);
                float y = _doorParametrStart;   // -5 , 90   , 42.162 , -42
                while (y >= _doorParametrEnd)
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

                float y = _closePatametr;
                while (y >= _closePatametr2)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y--;
                }
                DoorEvent?.Invoke();
                yield return new WaitForSeconds(2.3f);
                transform.localRotation = Quaternion.Euler(transform.rotation.x, _finishBrokenParametr, transform.rotation.z);
            }
            else
            {
                Debug.Log(" 4");
                DoorEventOpen?.Invoke();
                yield return new WaitForSeconds(2.5f);
                float y = _doorParametrStart;
                while (y <= _doorParametrEnd)
                {
                    transform.localRotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
                    yield return new WaitForSeconds(0.01f);
                    y++;
                }
            }
        }
        DoorAction(false);
        if (open)
            open = false;
        else open = true;
    }
}
