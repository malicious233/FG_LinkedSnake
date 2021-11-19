using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : GridObject, IMoveable, IRotatable
{
    GridObjectMovement movement;
    InputManager input;

    public Vector2Int gridPosition;
    MyLinkedList<SnakePart> SnakeParts;

    [SerializeField] GameObject snakePartPrefab;
    [SerializeField] float moveInterval;

    Coroutine moveIntervalRoutine;
    IEnumerator MoveInteralCoroutine()
    {
        while (0 == 0)
        {
            yield return new WaitForSeconds(moveInterval);
            MoveSnake(Direction);
        }
    }

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

    private Vector2Int direction;
    public Vector2Int Direction 
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    #region Methods

    public void MoveSnake(Vector2Int _direction)
    {
        if (_direction != Vector2Int.zero)
        {
            Vector2Int moveToPos = Position + _direction;
            Move(moveToPos);
            Direction = _direction;
        }
    }

    public bool Move(Vector2Int _position)
    {
        if (grid.CheckOutOfBounds(_position))
        {
            return false;
        }

        GridObject gridObject = grid.CheckTile(_position);

        if (gridObject != null)
        {
            //This could be a nice switch statement if this part expands, or just redone to be better
            if (gridObject.CompareTag("Tile"))
            {
                return false;
            }
            if (gridObject.CompareTag("Apple"))
            {
                Destroy(gridObject.gameObject);
                ExtendTail();
            }
        }
        Vector2Int prevGridPos = Position;
        Position = _position;
        movement.MoveTransform(_position);

        SnakeParts.first?.value.Move(prevGridPos);
       

        return true;
    }

    public void ExtendTail()
    {
        Vector2Int prevGridPos = Position;
        Vector2 prevPos = transform.position;

        GameObject obj = Instantiate(snakePartPrefab, prevPos, Quaternion.identity);
        SnakePart gridObj = obj.GetComponent<SnakePart>();

        MyNode<SnakePart> node = SnakeParts.AddNodeLast(gridObj);
        gridObj.snakePart = node;
        gridObj.Position = prevGridPos;
        grid.UpdateGridObjectPosition(gridObj, prevGridPos);

    }

    #endregion

    #region Unity Methods
    public override void Awake()
    {
        base.Awake();
        SnakeParts = new MyLinkedList<SnakePart>();
        movement = GetComponent<GridObjectMovement>();
        input = GetComponent<InputManager>();
    }

    public void Start()
    {
        moveIntervalRoutine = StartCoroutine(MoveInteralCoroutine());
    }

    public void Update()
    {
        //MoveSnake(input.inputVector);
        if (input.inputVector != Vector2Int.zero)
        {

            Direction = input.inputVector;
        }
        
    }

    
    #endregion
}
