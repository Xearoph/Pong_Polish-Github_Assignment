using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColour : MonoBehaviour
{
    public GameObject[] walls;
    public MeshRenderer materialChange;
    private void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall" + "BoundRight" + "BoundLeft");
        materialChange = GetComponent<MeshRenderer>();
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
        materialChange.material.color = Random.ColorHSV(0f, 1f, 1f, 1);
    }
}
