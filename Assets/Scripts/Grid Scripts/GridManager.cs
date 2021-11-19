using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    ///Singleton object which handles things on the grid

    public GridObject[,] gridArray;

    [Header("GRID SETTINGS:")]
    public int width;
    public int height;

    [Tooltip("Space in units between each tile")]
    public float spacing;

    #region Methods
    /// <summary>
    /// Updates said gridObjects position in the gridArray
    /// </summary>
    /// <param name="object"></param>
    /// <param name="gridPosition"></param>
    public void UpdateGridObjectPosition(GridObject _object, Vector2Int _gridPosition)
    {
        if (CheckOutOfBounds(_gridPosition))
        {
            return;
        }
        gridArray[_object.Position.x, _object.Position.y] = null;
        gridArray[_gridPosition.x, _gridPosition.y] = _object;
        
    }

    /// <summary>
    /// Returns a bool wether or not this grid position is out of bounds
    /// </summary>
    /// <param name="_gridPosition"></param>
    /// <returns>bool</returns>
    public bool CheckOutOfBounds(Vector2Int _gridPosition)
    {
        if (_gridPosition.x >= width || _gridPosition.y >= height)
        {
            Debug.Log("Out of bounds!");
            return true;
        }
        else if (_gridPosition.x < 0 || _gridPosition.y < 0)
        {
            Debug.Log("Out of bounds!");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the GridObject from given position
    /// </summary>
    /// <param name="_gridPosition"></param>
    /// <returns>GridObject or null</returns>
    public GridObject CheckTile(Vector2Int _gridPosition)
    {
        if (CheckOutOfBounds(_gridPosition))
        {
            return null;
        }
        if (gridArray[_gridPosition.x, _gridPosition.y] != null)
        {
            Debug.Log("Bonk");
            return gridArray[_gridPosition.x, _gridPosition.y];
        }
        return null;
    }

    #endregion

    public void Awake()
    {
        gridArray = new GridObject[width, height];
    }
}
