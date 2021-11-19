using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleObject : GridObject
{
    private Vector2Int gridPosition;
    public override Vector2Int Position
    {
        get
        {
            return gridPosition;
        }
        set
        {

            gridPosition = value;
            grid.UpdateGridObjectPosition(this, value);
        }
    }

    
}
