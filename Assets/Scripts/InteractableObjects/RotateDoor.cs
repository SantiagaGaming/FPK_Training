using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;


public class RotateDoor : Door
{
    [SerializeField] private bool _inside;

    override protected IEnumerator UseDoor(bool value)
    {
        DoorAction(true);
            if (!_inside)
            {
                if (!value)
                {
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
}
