using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    //Component which lets you place tiles in the editor. Requires a Gridobject inheriting component

    GridManager grid;
    GridObject gridObject;
    [SerializeField] Vector2Int gridPosition;

    private void Start()
    {
        gridObject = GetComponent<GridObject>();

        gridObject.Position = gridPosition;
        
    }

    public void OnValidate()
    {
        grid = FindObjectOfType<GridManager>();
        transform.position = new Vector3(gridPosition.x * grid.spacing, gridPosition.y * grid.spacing, 0);
    }
}
