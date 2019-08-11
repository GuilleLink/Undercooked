using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    private Food food;
    public Canvas canvas;

    private void Start()
    {
        food = GetComponent<Food>();
    }


    private void Update()
    {
        if (food.GetStatus() == FoodStatus.RAW && food.currentState.processingTime != 0)
        {
            foregroundImage.fillAmount = food.currentState.currentTime / food.currentState.processingTime;
        }
    }

    private void LateUpdate()
    {
        Camera camera = Camera.main;
        canvas.transform.LookAt(canvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }


}
