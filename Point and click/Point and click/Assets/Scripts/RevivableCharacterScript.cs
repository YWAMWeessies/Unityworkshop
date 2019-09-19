using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RevivableCharacterScript : MonoBehaviour
{
    public CauldronSO cauldron;
    private bool _isRevived;
    public float ReviveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Revive();
    }

    private void Revive()
    {
        _isRevived = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRevived)
        {
            TurnCharacterUpright();
        }

        if(cauldron._ingredientsInCauldron >= 3)
        {
            _isRevived = true;
        }
    }

    private void TurnCharacterUpright()
    {
        Quaternion q = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * ReviveSpeed);

        if(transform.position.y < 1)
        {
            transform.Translate(new Vector3(0, ReviveSpeed * 0.02f));
        }
    }
}
