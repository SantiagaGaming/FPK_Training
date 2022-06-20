using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
public class RailDoor : Door
{
    override protected IEnumerator UseDoor(bool value)
    {
        DoorAction(true);
        if (value)
        {
            int x = 40;
            while (x >= 0)
            {
                transform.localPosition -= new Vector3(0.0125f, 0, 0);
                yield return new WaitForSeconds(0.03f);
                x--;
            }
        }
        else
        {
            if(handle!=null)
            {
                int rot = 0;
                while (rot <= 20)
                {
                    handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
                    yield return new WaitForSeconds(0.008f);
                    rot++;
                }
            }

            int x = 0;
            while (x <= 40)
            {
                transform.localPosition += new Vector3(0.0125f, 0, 0);
                yield return new WaitForSeconds(0.03f);
                x++;
            }
            if(handle!=null)
            {
                int rot = 0;
                while (rot <= 20)
                {
                    handle.transform.localEulerAngles += new Vector3(0, 0, 1);
                    yield return new WaitForSeconds(0.008f);
                    rot++;
                }
            }
        }
        DoorAction(false);

        if (open)
            open = false;
        else open = true;
    }
}
