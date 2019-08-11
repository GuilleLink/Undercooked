using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    private Material original;
    public Material highlighted;
    private Material[] materials;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        materials = renderer.materials;
        try
        {
            original = materials[1];
        }
        catch{
            original = materials[0];
        }
    }

    public void highlight()
    {
        try
        {
            materials[1] = highlighted;
        }
        catch
        {
            materials[0] = highlighted;
        }
        renderer.materials = materials;
    }

    public void unhighlight()
    {
        try
        {
            materials[1] = original;
        }
        catch
        {
            materials[0] = original;
        }
        renderer.materials = materials;
    }
}
