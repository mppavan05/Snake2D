using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{

    private Vector2Int FoodGridPosition;
    private GameObject foodGameObject;
    private int hight;
    private int width;
    private Snake snake;

    public LevelGrid (int width , int hight)
    {
        this.width = width;
        this.hight = hight;


        SpwanFood();

    }
    public void Setup(Snake snake)
    {
        this.snake = snake;
    }






    private void SpwanFood()
    {
        FoodGridPosition = new Vector2Int(Random.Range(0,width) , Random.Range(0,hight));

        foodGameObject = new GameObject("Food" , typeof(SpriteRenderer));
       // foodGameObject.GetComponent<SpriteRenderer>().sprite = Game_assets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(FoodGridPosition.x, FoodGridPosition.y);
    }

    public void SnakeMoved(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == FoodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpwanFood();
           // CMDebug.TextPopupMouse("snake ate food");
        }
    }

    
}
