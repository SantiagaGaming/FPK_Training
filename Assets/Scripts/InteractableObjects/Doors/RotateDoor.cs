using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;


public class RotateDoor : Door
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
                if (handle != null)
                    StartCoroutine(RotateHandle());
                yield return new WaitForSeconds(0.5f);
                int y = 0;
                    while (y >= -90)
                    {
                    transform.localEulerAngles += new Vector3(0, 1, 0);
                        yield return new WaitForSeconds(0.01f);
                        y--;
                    }
                }
                else
                {
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
                if (handle != null)
                    StartCoroutine(RotateHandle());
                yield return new WaitForSeconds(0.5f);
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
    private IEnumerator RotateHandle()
    {
            int rot = 0;
            while (rot <= 45)
            {
            if(!_x && !_down)
                handle.transform.localEulerAngles += new Vector3(0, 0, 1);
            else if(!_x && _down)
                handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
            else if(_x && !_down)
                handle.transform.localEulerAngles -= new Vector3(1, 0, 0);
            else
                handle.transform.localEulerAngles += new Vector3(1, 0, 0);
            yield return new WaitForSeconds(0.008f);
                rot++;
            }
            while (rot>=0)
        {
            if(!_x && !_down)
             handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
            else if (!_x && _down)
                handle.transform.localEulerAngles += new Vector3(0, 0, 1);
            else if (_x && !_down)
                handle.transform.localEulerAngles += new Vector3(1, 0, 0);
            else
                handle.transform.localEulerAngles -= new Vector3(1, 0, 0);
            yield return new WaitForSeconds(0.008f);
            rot--;
        }
    }
}
