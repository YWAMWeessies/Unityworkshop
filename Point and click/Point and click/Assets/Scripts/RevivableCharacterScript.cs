using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RevivableCharacterScript : MonoBehaviour
{
    public UnityEvent m_Revived = new UnityEvent();
    private bool _isRevived;
    public float ReviveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_Revived.AddListener(Revive);

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
