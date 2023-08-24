using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _vrPlayer;

    public Transform GetPlayerTransform()
    {
        if (!_desktopPlayer.activeSelf)
        {
            return _vrPlayer.transform;
        }
        else return _desktopPlayer.transform;
    }
    public bool VrMode()
    {
        if (!_desktopPlayer.activeSelf)
        {
            return true;
        }
        else return false;
    }
}
