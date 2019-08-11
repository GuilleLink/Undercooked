using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public List<RecipeIngredient> accepts;
    public List<Food> foodContent;
    public GameObject contentsParent;
    public List<Image> iconList;
    public Canvas canvas;
    public int maxElements = 3;


    private void Start()
    {
        foodContent = new List<Food>();
    }

    private Sprite GetSprite(Food food)
    {
        Sprite result = null;
        
        foreach (RecipeIngredient item in accepts)
        {
            if (item.foodType == food.type && item.foodStatus == food.GetStatus())
            {
                result = item.icon;
                break;
            }
        }
        
        return result;
    }


    public bool CanAccept(Food food)
    {
        bool result = false;
        if (foodContent.Count < maxElements)
        {
            foreach (RecipeIngredient item in accepts)
            {
                if (item.foodType == food.type && item.foodStatus == food.GetStatus())
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }

    public void Receive(Food food)
    {
        foodContent.Add(food);
        food.transform.SetParent(contentsParent.transform);
        iconList[foodContent.Count - 1].sprite = GetSprite(food);
        food.hideModel();
    }

    private void LateUpdate()
    {
        Camera camera = Camera.main;
        canvas.transform.LookAt(canvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}
