using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    TOMATO,
    ONION,
    MUSHROOM,
    BLUEMILK
}


public class Food : MonoBehaviour
{
    public FoodType type;
    public FoodState currentState;

    public void Start()
    {
        
    }

    public void ChangeState(FoodState newState)
    {
        currentState.gameObject.SetActive(false);
        newState.gameObject.SetActive(true);
        currentState = newState;

    }

    public void ProcessFood(float time)
    {
        currentState.ProcessFood(time);
    }

    public FoodStatus GetStatus()
    {
        return currentState.status;
    }

    public void Delete()
    {
        //pool.ReturnToPool(this.gameObject);
    }

    public void hideModel()
    {

    }

    private void Update()
    {
        
    }

}
