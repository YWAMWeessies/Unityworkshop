using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag.Equals("Cauldron"))
        {
            Destroy(gameObject);
            Debug.Log(name + " went in the cauldron");
        }
    }
}
