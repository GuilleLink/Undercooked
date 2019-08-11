using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredient;

    void Start()
    {
        
    }

    public MovableObject GetIngredient()
    {
        GameObject newObject = Instantiate(ingredient);
        MovableObject movable = newObject.GetComponent<MovableObject>();
        return movable;
    }
}
