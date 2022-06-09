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
    [SerializeField] private GameObject _handle;
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
        if (!value)
        {
            Debug.Log("Открываем");
            int z = 0;
            while (z <= 90)
            {
                _handle.transform.localRotation = Quaternion.Euler(0, 0, z);
                yield return new WaitForSeconds(0.01f);
                z++;
            }
            int y = 0;
            while (y >= -90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                yield return new WaitForSeconds(0.01f);
                y--;
            }
        }
        else
        {
            Debug.Log("Закрываем");
            int y = -90;
            while (y <= 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                yield return new WaitForSeconds(0.01f);
                y++;
            }
            int z = 90;
            while (z >= 0)
            {
                _handle.transform.localRotation = Quaternion.Euler(0, 0, z);
                yield return new WaitForSeconds(0.01f);
                z--;
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
