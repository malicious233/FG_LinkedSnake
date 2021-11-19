using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotatable
{
    //Interface for allowing said gridobject to have a direction
    
    public Vector2Int Direction
    {
        get;
        set;
    }
}
