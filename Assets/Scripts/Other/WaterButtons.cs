using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterButtons : BaseObject
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _waterLevel;
    [SerializeField] private GameObject _water;
    private Collider _collider;
    private bool _canOn = true;
    private void Start()
    {

        _particleSystem.Stop();
        _collider = GetComponent<Collider>();
    }

    public override void OnClicked(InteractHand interactHand)
    {
        if (_canOn)
        {
            _collider.enabled = false;
            _particleSystem.Play();
            StartCoroutine(StopWater());
        }
        else
        {
            _collider.enabled = false;
            StartCoroutine(Delay());
        }

    }

    private IEnumerator StopWater()
    {

        if (_waterLevel.transform.localScale.y > 0)
        {
            if (_water.activeSelf)
            {
                yield return new WaitForSeconds(1);
                if (_waterLevel.transform.localScale.y > 0)
                {
                    _waterLevel.gameObject.transform.localScale -= new Vector3(0, 0.1f, 0);
                    yield return new WaitForSeconds(1);
                }
                if (_waterLevel.transform.localScale.y > 0)
                {

                    _waterLevel.gameObject.transform.localScale -= new Vector3(0, 0.1f, 0);
                    yield return new WaitForSeconds(1);
                }


            }
            else
            {
                yield return new WaitForSeconds(3);

            }
            _particleSystem.Stop();
            _collider.enabled = true;
        }
        else
        {
            _canOn = false;
            _particleSystem.Stop();
            yield return new WaitForSeconds(2);
            _collider.enabled = true;
        }

    }
    public void SetCondition(bool value)
    {
        _canOn = value;
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        _collider.enabled = true;
    }
}
