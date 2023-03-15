using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] private Transform _resetPos;
    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 1.5f);
    }
    private void Start()
    {
        StartCoroutine(ChangePosition());
    }
    private IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        transform.position = _resetPos.position;
        StartCoroutine(ChangePosition());
    }
}
