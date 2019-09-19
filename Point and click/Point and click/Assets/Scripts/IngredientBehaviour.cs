using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBehaviour : MonoBehaviour
{
    public CauldronSO cauldronVariables;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag.Equals("Cauldron"))
        {
            Destroy(gameObject);
            cauldronVariables._ingredientsInCauldron++;
            Debug.Log(name + " went in the cauldron");
        }
    }
}
