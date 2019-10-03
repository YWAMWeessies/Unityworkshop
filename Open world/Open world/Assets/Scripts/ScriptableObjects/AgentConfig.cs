using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentConfig", menuName = "ScriptableObjects/AgentConfig", order = 1)]
public class AgentConfig : ScriptableObject
{
    public float AwarenessRange;

    public float FieldOfViewAngle;

    public float WanderingRadius;

}
