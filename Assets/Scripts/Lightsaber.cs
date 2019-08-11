using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightsaberType
{
    LUKE,
    YODA
}

public class Lightsaber : MonoBehaviour
{

    public LightsaberType type;
    public OpenLightsaber currentState;


    void Start()
    {
        
    }

    public void ChangeState(OpenLightsaber newState)
    {
        currentState.gameObject.SetActive(false);
        newState.gameObject.SetActive(true);
        currentState = newState;
    }
        
    public LightSaberStatus GetStatus()
    {
        return currentState.status;
    }

}
