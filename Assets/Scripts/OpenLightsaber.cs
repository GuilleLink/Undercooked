using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightSaberStatus
{
    OPEN,
    CLOSED
}

public class OpenLightsaber : MonoBehaviour
{

    public LightSaberStatus status;
    public GameObject mesh;
    public OpenLightsaber nextState;
    private Lightsaber parentLightsaber;

    void Start()
    {
        parentLightsaber = GetComponentInParent<Lightsaber>();

    }

    void Update()
    {
            
    }

    public void activateSaber()
    {
        if (status == LightSaberStatus.CLOSED)
        {
            parentLightsaber.ChangeState(nextState);
        }
    }

    public void deactivateSaber()
    {
        if (status == LightSaberStatus.OPEN)
        {
            parentLightsaber.ChangeState(nextState);
        }
    }

}
