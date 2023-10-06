using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetZoneButton : BaseMenuButton
{
    protected override void MenuButtonClick()
    {
        ObjectToHide.SetActive(false);
        var zone = InstanceHandler.Instance.ZoneTags.FirstOrDefault(z => z.RoomName == InstanceHandler.Instance.CurrentRoom);
        zone.gameObject.SetActive(true);
        Debug.Log("1111111111111111111"+ InstanceHandler.Instance.CurrentRoom);
    }
}
