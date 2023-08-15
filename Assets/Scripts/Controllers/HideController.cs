using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    [SerializeField] private int _count;
    public List<string> HidedObjectNames { get; private set; } = new List<string>();
    private void Start()
    {
        StartCoroutine(HideDelay());
    }
    private IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(0.5f);
        HideInvoke();
    }
    private void HideInvoke()
    {
        for (int i = 0; i < _count; i++)
        {
           HidedObjectNames.Add(InstanceHandler.Instance.HideObject());
        }
    }
}
