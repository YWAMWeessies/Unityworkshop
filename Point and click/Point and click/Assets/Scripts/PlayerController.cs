using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float AccelerationSpeed;

    private NavMeshAgent _agent;

    void Awake() {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent.speed = MovementSpeed;
        _agent.acceleration = AccelerationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray cameraPoint = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cameraPoint, out hit, Mathf.Infinity))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
