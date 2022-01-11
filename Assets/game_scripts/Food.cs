using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public Text Myscoretext;
    private int ScoreNum;


    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();

        ScoreNum = 0;

        Myscoretext.text = "Score: " + ScoreNum;
    }

    private void RandomizePosition()
    {
        Bounds boundes = this.gridArea.bounds;

        float x = Random.Range(boundes.min.x,boundes.max.x);
        float y = Random.Range(boundes.min.y, boundes.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }


    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.tag == "Player")
        {
            RandomizePosition();

            ScoreNum += 10;

            Myscoretext.text = "Score: " + ScoreNum;
            
        }
    }
}

