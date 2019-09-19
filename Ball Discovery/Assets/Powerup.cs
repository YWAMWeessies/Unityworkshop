using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Vector3 xyz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Power-up picked up");
            other.transform.localScale = xyz;
            other.transform.position = new Vector3(transform.position.x, transform.position.y + xyz.y, transform.position.z);
            Destroy(transform.gameObject);
        }
    }
}
