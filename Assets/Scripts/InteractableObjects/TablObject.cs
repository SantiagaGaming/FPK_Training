using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TablObject : MonoBehaviour
{
    public static TablObject Instance;
    [SerializeField] private GameObject _tabl;
    private float _delay = 4;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }


    public void SetNewPosition(Vector3 newPos)
    {
        _tabl.transform.position = newPos;
        StopCoroutine("EnableObjectDelay");
        StartCoroutine("EnableObjectDelay");
    }
    private IEnumerator EnableObjectDelay()
    {
        _tabl.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delay);
        _tabl.gameObject.SetActive(false);
    }
}

