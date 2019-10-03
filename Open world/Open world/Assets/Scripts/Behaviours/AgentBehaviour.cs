using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviour : MonoBehaviour
{
    public enum PredatorStates
    {
        None,
        Wandering,
        Chasing,
    }

    public AgentConfig agentConfig;

    public Transform playerTransform;

    private NavMeshAgent _agent;

    private PredatorStates _currentState;

    public delegate void PlayerReachedAction();
    public static event PlayerReachedAction PlayerReached;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (!playerTransform)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        _currentState = PredatorStates.Wandering;
        Debug.Log("Start state: " + _currentState);
    }

    private void Update()
    {
        switch (_currentState)
        {
            case PredatorStates.Wandering: UpdateWanderingState(); break;
            case PredatorStates.Chasing: UpdateChasingState(); break;
        }
    }

    private void SwitchStates(PredatorStates state)
    {
        _currentState = state;
        Debug.Log("Switching states to: " + _currentState);
    }

    private void UpdateWanderingState()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            setRandomDestinationForAgent(-agentConfig.WanderingRadius, agentConfig.WanderingRadius);
        }

        if (IsPlayerInFieldOfView())
        {
            SwitchStates(PredatorStates.Chasing);
        }

        Debug.DrawRay(transform.position, transform.forward * agentConfig.AwarenessRange, Color.grey);
    }

    private void UpdateChasingState()
    {
        if (!IsPlayerInFieldOfView())
        {
            SwitchStates(PredatorStates.Wandering);
            setRandomDestinationForAgent(-agentConfig.WanderingRadius, agentConfig.WanderingRadius);

        } else
        {
            _agent.SetDestination(playerTransform.position);
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            PlayerReached?.Invoke();
        }
    }

    private bool IsPlayerInRange()
    {
        return (Vector3.Distance(transform.position, playerTransform.position) < agentConfig.AwarenessRange);
    }

    private bool IsPlayerInFieldOfView()
    {
        Vector3 rayDirection = playerTransform.position - transform.position;
        return (Vector3.Angle(rayDirection, transform.forward) <= agentConfig.FieldOfViewAngle);
    }

    private void setRandomDestinationForAgent(float minPos, float maxPos)
    {
        Vector3 currentAgentPosition = transform.position;
        Vector3 newDestination = new Vector3(currentAgentPosition.x + Random.Range(minPos, maxPos), currentAgentPosition.y, currentAgentPosition.z + Random.Range(minPos, maxPos));
        _agent.SetDestination(newDestination);
    }
}
