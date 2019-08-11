using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{

    public GameObject movableAnchor;
    MovableObject movable;

    void Start()
    {
        movable = movableAnchor.GetComponentInChildren<MovableObject>();
    }

    public bool HasMovable()
    {
        return movable != null;
    }

    public MovableObject GetMovable()
    {
        return movable;
    }

    public void SetMovable(MovableObject newMovable)
    {
        movable = newMovable;

        newMovable.gameObject.transform.SetParent(movableAnchor.transform);

        newMovable.gameObject.transform.localPosition = Vector3.zero;
    }

    public void RemoveMovable()
    {
        movable = null;
    }

}
