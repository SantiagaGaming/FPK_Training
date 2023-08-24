using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchObject : BaseObject
{
    [SerializeField] private GameObject _light;
    [SerializeField] private Animator _animator;
    private bool _on = false;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if(!_on)
        {
            _animator.SetTrigger("OnAnim");
            _light.SetActive(true);
            _on = true;
        }
        else
        {
            _animator.SetTrigger("OffAnim");
            _light.SetActive(false);
            _on = false;
        }
    }
}
