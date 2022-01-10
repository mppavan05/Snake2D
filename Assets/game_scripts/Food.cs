using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
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
        }
    }
}

