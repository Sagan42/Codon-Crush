using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public int x
    {
        get;
        private set;
    }

    public int y
    {
        get;
        private set;
    }

    [HideInInspector] public int id;

    public void ChangePosition (int newX, int newY)
    {
        x = newX;
        y = newY;
        gameObject.name = string.Format("Sprite [{0}] [{1}]", x, y);
    }

    private void OnMouseDown()
    {
        if (OnMouseOverItemEvent != null)
        {
            OnMouseOverItemEvent(this);
        }
    }

    public delegate void OnMouseOverItem(Grid item);
    public static event OnMouseOverItem OnMouseOverItemEvent;
}
