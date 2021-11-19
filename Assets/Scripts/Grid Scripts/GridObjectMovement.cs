using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectMovement : MonoBehaviour
{
    GridManager grid;

    public void Awake()
    {
        grid = FindObjectOfType<GridManager>();
    }

    /// <summary>
    /// Moves this objects transform
    /// </summary>
    /// <param name="_gridPosition"></param>
    public void MoveTransform(Vector2Int _gridPosition)
    {
        Vector3 pos = (Vector2)_gridPosition * grid.spacing;
        transform.position = pos;
    }

    //TODO: Move some methods from SnakeHead into here
}
