using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_assets : MonoBehaviour
{
    public static Game_assets i;


    private void Awake()
    {
        i = this;
    }
    public Sprite SnakeHeadSprite;
   // public Sprite foodSprite;

}
