using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField]
    public int cookTime;
    private int currentTime;

    public event Action<float> OnCookPctChanged = delegate { };

    private void OnEnable()
    {
        currentTime = 0;
    }

    public void ModifyCook(int amount)
    {
        float currentCookPct = (float)currentTime / (float)cookTime;
        OnCookPctChanged(currentCookPct);
    }

    

}
