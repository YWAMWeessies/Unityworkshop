using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReachedPlayerEvent : MonoBehaviour
{

    private bool isEventRunning = false;

    void OnEnable()
    {
        AgentBehaviour.PlayerReached += takeDamage;
    }


    void OnDisable()
    {
        AgentBehaviour.PlayerReached -= takeDamage;
    }


    void takeDamage()
    {
        if (!isEventRunning)
        {
            isEventRunning = true;
        }
    }
}
