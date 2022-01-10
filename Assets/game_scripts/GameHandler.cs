using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Snake snake;
    private LevelGrid levelGrid;

    void Start()
    {
        Debug.Log("GameHandler.Start");
        GameObject SnakeHeadGameObject = new GameObject();
        SpriteRenderer SnakeHeadSpritRenderer = SnakeHeadGameObject.AddComponent<SpriteRenderer>();
        // snakeSpriteRenderer.sprit = Game_assets.i.SnakeHeadSprite;

        levelGrid = new LevelGrid(20, 20);


        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
