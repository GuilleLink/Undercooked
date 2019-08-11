using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{

    private bool isCooking = false;
    private Food currentFood;
    private Holder foodHolder;

    // Start is called before the first frame update
    void Start()
    {
        foodHolder = GetComponent<Holder>();
    }

    public bool StartCooking()
    {
        if (foodHolder.HasMovable())
        {
            MovableObject movable = foodHolder.GetMovable();
            currentFood = movable.GetComponent<Food>();
            if (currentFood != null && currentFood.GetStatus() == FoodStatus.CUT)
            {
                isCooking = true;
            }
        }

        return isCooking;
    }

    public void StopCooking()
    {
        isCooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            currentFood.ProcessFood(Time.deltaTime);
            if (currentFood.GetStatus() != FoodStatus.CUT)
            {
                isCooking = false;
            }
        }
    }

}
