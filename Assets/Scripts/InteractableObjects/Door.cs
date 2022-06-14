using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;


public class Door : BaseObject
{
    [SerializeField] private bool _inside;
    private bool _canAction = true;
    private bool _open = false;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_canAction)
            StartCoroutine(UseDoor(_open));
    }
    private IEnumerator UseDoor(bool value)
    {
        Player.Instance.CanMove = false;
        GetComponent<Collider>().isTrigger = true;
        _canAction = false;
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
        Player.Instance.CanMove = true;
        _canAction = true;
        GetComponent<Collider>().isTrigger = false;
        if (_open)
            _open = false;
        else _open = true;
    }
}
