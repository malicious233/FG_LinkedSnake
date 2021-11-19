using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    //Abstract class for objects that exists on grids
    public abstract Vector2Int Position
    {
        get;
        set;
    }
    protected GridManager grid; 

    public virtual void Awake()
    {
        grid = FindObjectOfType<GridManager>();
    }

}
