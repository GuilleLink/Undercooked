using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodStatus
{
    RAW,
    CUT,
    COOKED,
    BURNED
}

public class FoodState : MonoBehaviour
{

    public FoodStatus status;
    public GameObject mesh;
    public float processingTime;
    public FoodState nextState;
    public float currentTime;
    private Food parentFood;
    public GameObject barra;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        parentFood = GetComponentInParent<Food>();
        barra.SetActive(false);
    }
    
    public void ProcessFood(float time)
    {
        
        if (currentTime >= processingTime)
        {
            barra.SetActive(false);
            parentFood.ChangeState(nextState);
        }
        else
        {
            barra.SetActive(true);
            currentTime += time;
        }
    }


}
