using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper : MonoBehaviour
{

    private bool isChopping = false;
    private Food currentFood;
    private Holder chopperHolder;
    private Lightsaber currentLightsaber;
    private Player player;
    public AudioSource open;
    public AudioSource close;
    public AudioSource cut;

    // Start is called before the first frame update
    void Start()
    {
        chopperHolder = GetComponent<Holder>();
    }

    public bool StartChopping(Player p)
    {
        player = p;
        if (chopperHolder.HasMovable())
        {
            MovableObject movable = chopperHolder.GetMovable();
            currentFood = movable.GetComponent<Food>();
            if (currentFood != null && currentFood.GetStatus() == FoodStatus.RAW)
            {
                isChopping = true;
                player.lightsaber.currentState.activateSaber();
            }
        }
        cut.Play();
        return isChopping;
    }

    public void StopChopping()
    {
        isChopping = false;
        player.lightsaber.currentState.deactivateSaber();
        player.StopChopping();
        cut.Pause();
        close.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChopping)
        {
            currentFood.ProcessFood(Time.deltaTime);
            
            if (currentFood.GetStatus() != FoodStatus.RAW)
            {
                StopChopping();
            }
        }
    }
}
