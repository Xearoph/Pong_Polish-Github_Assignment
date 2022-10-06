using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColour : MonoBehaviour
{
    public GameObject[] walls;
    private void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall" + "BoundRight" + "BoundLeft");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerLeft" || collision.gameObject.tag == "PlayerRight")
        {
            ChangeColour();
        }
    }
    void ChangeColour()
    {

    }
}
