using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieScript : MonoBehaviour
{
    public GameObject Light;
    public GameObject Cauldron;
    public float WalkingSpeed = 1f;
    public float RotationSpeed = 1f;
    private bool _lightsOn = false;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Cauldron != null)
        {
            Walk();
        }

        _lightsOn = Light.active;
    }

    private void Walk()
    {
        //move towards or away from the cauldron
        if(!_lightsOn)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cauldron.transform.position - transform.position), RotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(origin - transform.position), RotationSpeed * Time.deltaTime);
        }

        transform.position += transform.forward * Time.deltaTime * WalkingSpeed;
    }
}
