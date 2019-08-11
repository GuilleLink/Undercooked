using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDetection : MonoBehaviour
{

    List<Furniture> furnitureList;
    Furniture current;

    private void Start()
    {
        furnitureList = new List<Furniture>();
    }

    private void Update()
    {
        SelectFurniture();
    }

    public Furniture GetSelected()
    {
        return current;
    }

    private void OnTriggerEnter(Collider other)
    {
        Furniture f = other.gameObject.GetComponent<Furniture>();
        if (f != null)
        {
            furnitureList.Add(f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Furniture f = other.gameObject.GetComponent<Furniture>();
        if (f != null)
        {
            Chopper fChopper = f.GetComponent<Chopper>();
            if (fChopper != null)
            {
                fChopper.StopChopping();
            }
            furnitureList.Remove(f);
        }
    }

    private void SelectFurniture()
    {
        if (current != null)
        {
            current.unhighlight();
        }

        if (furnitureList.Count > 0)
        {
            Furniture selected = null;
            float minDistance = 1100f;
            foreach (Furniture f in furnitureList)
            {
                float distance = Vector3.Distance(transform.position, f.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    selected = f;
                }
            }

            if (selected != null)
            {
                current = selected;
                current.highlight();
            }
            
        }
    }
}
