using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] GameObject appleObject;
    [SerializeField] float appleSpawnInterval;

    Coroutine appleSpawnRoutine;
    GridManager grid;
    IEnumerator AppleSpawnCoroutine()
    {
        while (0 == 0) 
        {
            yield return new WaitForSeconds(appleSpawnInterval);
            Vector2Int randomPos = new Vector2Int();
            randomPos.x = Random.Range(0, grid.width);
            randomPos.y = Random.Range(0, grid.height);
            SpawnApple(randomPos);
        }
    }

    public void SpawnApple(Vector2Int _gridPos)
    {
        if (grid.CheckTile(_gridPos) != null)
        {
            return;
        }
        GameObject appleObj = Instantiate(appleObject);
        GridObjectMovement movement = appleObj.GetComponent<GridObjectMovement>();
        GridObject gridobj = appleObj.GetComponent<GridObject>();

        gridobj.Position = _gridPos;
        movement.MoveTransform(_gridPos);
        //I should've moved Position and Movetransform to be in the same component so I wont have to getcomponent twice. 
    }
    private void Awake()
    {
        grid = FindObjectOfType<GridManager>();
        appleSpawnRoutine = StartCoroutine(AppleSpawnCoroutine());
    }
}
