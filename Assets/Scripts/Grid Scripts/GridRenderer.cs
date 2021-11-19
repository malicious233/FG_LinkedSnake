using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(GridManager))]
public class GridRenderer : MonoBehaviour
{
    //Renders the grid with a linerenderer

    GridManager grid;
    LineRenderer line;

    private void Awake()
    {
        grid = GetComponent<GridManager>();
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        List<Vector3> cornersOfGrid = new List<Vector3>();
        line.positionCount = 4;
        float tileSize = grid.spacing;
        cornersOfGrid.Add(new Vector2(-tileSize, -tileSize));
        cornersOfGrid.Add(new Vector2(-tileSize, grid.height * tileSize));
        cornersOfGrid.Add(new Vector2(grid.width * tileSize, grid.height * tileSize));
        cornersOfGrid.Add(new Vector2(grid.width * tileSize, -tileSize));

        Vector3[] cornersOfGridArray = cornersOfGrid.ToArray();

        line.SetPositions(cornersOfGridArray);
    }
}
