using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
public class TurnedRailDoor : Door
{
    override protected IEnumerator UseDoor(bool value)
    {
        DoorAction(true);
        if (value)
        {
            int x = 40;
            while (x >= 0)
            {
                transform.localPosition -= new Vector3(0.0125f, 0, -0.0075f);
                yield return new WaitForSeconds(0.03f);
                x--;
            }
        }
        else
        {
            int x = 0;
            while (x <= 40)
            {
                transform.localPosition += new Vector3(0.0125f, 0, -0.0075f);
                yield return new WaitForSeconds(0.03f);
                x++;
            }

        }
        DoorAction(false);

        if (open)
            open = false;
        else open = true;
    }
}
