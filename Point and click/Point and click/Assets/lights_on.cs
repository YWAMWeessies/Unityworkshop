using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights_on : MonoBehaviour
{

    public GameObject Light;
    private IEnumerator _currentroutine;
    // Start is called before the first frame update
    void Start()
    {
        _currentroutine = LightsOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StopCoroutine(_currentroutine);
        _currentroutine = LightsOn();
        StartCoroutine(_currentroutine);
    }

    IEnumerator LightsOn()
    {
        while (true)
        {
            Light.SetActive(true);
            yield return new WaitForSeconds(5);
            StopCoroutine(_currentroutine);
            _currentroutine = LightsOff();
            StartCoroutine(_currentroutine);
            yield return null;
            

        }
    }

    private IEnumerator LightsOff()
    {
        while (true) {
            Light.SetActive(false);
            yield return null;
        }
    }
}
