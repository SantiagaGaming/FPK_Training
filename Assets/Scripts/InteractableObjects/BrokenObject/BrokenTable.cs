using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTable : SearchableObject

{
    [SerializeField] private Animator _animator;

    public override void EnableObject(bool value)
    {
        base.EnableObject(value);

        if (!value)
        {
            { StartCoroutine(Wait()); }
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        _animator.enabled = false;
        Obj.transform.localRotation = Quaternion.Euler(0, 5, 10);
    }
    
}
