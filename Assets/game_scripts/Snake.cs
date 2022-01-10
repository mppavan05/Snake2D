using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float grideMoveTimer;
    private float grideMoveTimerMax;
    private LevelGrid levelGrid;

    private List<Transform> Body;

    public Transform BodyPrefab;



    private void Start()
    {
        Body = new List<Transform>();
        Body.Add(this.transform);
    }






    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10 , 10);
        grideMoveTimerMax = 1f;
        grideMoveTimer = grideMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);

       

    }

    private void Update()
    {
        InputController();

        GridMovementController();
           
        
    }

    private void InputController()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -3)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +3;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +3)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -3;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +3)
            {
                gridMoveDirection.x = -3;
                gridMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -3)
            {
                gridMoveDirection.x = +3;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void GridMovementController()
    {
        grideMoveTimer += Time.deltaTime + 0.1f;
        if (grideMoveTimer >= grideMoveTimerMax)
        {
            grideMoveTimer -= grideMoveTimerMax;

            gridPosition += gridMoveDirection;


            // for snake growth
            for ( int i = Body.Count - 1; i > 0; i-- )
            {
                Body[i].position = Body[i - 1].position;
            }
            
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3 ( 0, 0, GetAngleFromVector(gridMoveDirection) -90 );

            levelGrid.SnakeMoved(gridPosition);
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }


    private void Grow()
    {
        Transform Bodys = Instantiate(this.BodyPrefab);

        Bodys.position = Body[Body.Count - 1].position;

        Body.Add(Bodys);
    }

    private void ResetState()
    {
        for (int i = 1; i < Body.Count; i++)
        {
            Destroy(Body[i].gameObject);
        }

        Body.Clear();
        Body.Add(this.transform);

        this.transform.position = Vector3.zero;
    }



    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.tag == "Food")
        {
            Grow();
        }

        else if (others.tag == "Wall")
        {
            ResetState();
        }
    }

}

