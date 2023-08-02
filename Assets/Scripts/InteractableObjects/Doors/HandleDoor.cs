using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoor : Door
{
    
    private bool _canOpen = true;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_canOpen)
            StartCoroutine(UseDoor(open));
    }
    protected override IEnumerator UseDoor(bool value)
    {
        _canOpen= false;

           var pos = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.35f, transform.position.z - 0.07f);
        TablObject.Instance.SetNewPosition(pos);

        if (handle != null)
            {

                int rot = 0;
                while (rot <= 20)
                {
                    handle.transform.localEulerAngles -= new Vector3(0, 0, 1);
                    yield return new WaitForSeconds(0.008f);
                    rot++;
                }
            }
            if (handle != null)
            {
                int rot = 0;
                while (rot <= 20)
                {
                    handle.transform.localEulerAngles += new Vector3(0, 0, 1);
                    yield return new WaitForSeconds(0.008f);
                    rot++;
                }
            }
       
        _canOpen = true;




    }
}
