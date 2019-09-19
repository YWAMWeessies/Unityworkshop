using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float AccelerationSpeed;

    public Transform item_position;

    private NavMeshAgent _agent;

    private GameObject _itemInHand;

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
        MovementViaCamera();
        
        if (Input.GetButtonDown("DropButton")) 
        {
            if (_itemInHand) {
                dropItem(_itemInHand);
            }
        }
    }

    private void MovementViaCamera() 
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

    void OnTriggerStay(Collider other) {
        PickUp(other);
    }

    private void PickUp(Collider other) 
    {
        if (Input.GetButtonDown("PickupButton")) 
        {
            if (other.tag.Equals("PickUp")) 
            {
                if (!_itemInHand) 
                {
                    PickUpItem(other.gameObject);
                } else {
                    Debug.Log("Drop item first!");
                }
            }
        }       
    }

    private void PickUpItem(GameObject item) 
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.transform.parent = this.transform;
        item.transform.SetPositionAndRotation(item_position.position, item_position.rotation);
        _itemInHand = item;
        Debug.Log("Picking up: " + item.name);
    }

    private void dropItem(GameObject item) 
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.transform.parent = null;
        _itemInHand = null;
        Debug.Log("Dropping item: " + item.name);
    }
}
