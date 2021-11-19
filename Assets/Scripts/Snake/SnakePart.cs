using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : GridObject, IMoveable
{
    GridObjectMovement movement;
    //public LinkedListNode<SnakePart> snakePart;
    public MyNode<SnakePart> snakePart;
    public Vector2Int gridPosition;




    #region Methods

    public override Vector2Int Position 
    {
        get
        {
            return gridPosition;
        }
        set
        {
            grid.UpdateGridObjectPosition(this, value);
            gridPosition = value;
        }
    }

    public bool Move(Vector2Int _position)
    {
        Vector2Int prevPos = Position;
        Position = _position;
        movement.MoveTransform(_position);
        //snakePart?.Next?.Value.Move(prevPos);
        snakePart?.next?.value.Move(prevPos);

        return true;
        
    }

    #endregion

    #region Unity Methods
    public override void Awake()
    {
        base.Awake();
        movement = GetComponent<GridObjectMovement>();
    }
    #endregion


}
