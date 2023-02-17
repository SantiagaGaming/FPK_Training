using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFadeIn : MonoBehaviour
{
    public bool FadeStart;
    private void Update()
    {

        if (FadeStart)
        {
            Player.Instance.FadeIn(1f, true);
            StartCoroutine(Delay());
        }


    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Instance.FadeOut(1f, false);
        FadeStart = false;
    }
}
