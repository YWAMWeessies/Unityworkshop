using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movement_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement_force = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement_force.normalized * (movement_speed * Time.fixedDeltaTime));
        }
    }
}
