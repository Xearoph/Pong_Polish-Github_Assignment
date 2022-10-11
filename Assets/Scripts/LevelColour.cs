using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColour : MonoBehaviour
{ 
    GameObject player;
    [SerializeField] SpriteRenderer materialChange;
    private void Start()
    {
        
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player.TryGetComponent<LevelColour>(out _))
        {
            // add script to gameobject
            player.AddComponent<LevelColour>();
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerLeft" || other.gameObject.tag == "PlayerRight")
        {
            materialChange.GetComponent<SpriteRenderer>();
            Debug.Log("HOIWERHJWEUH");
            ChangeColour();
        }
    }
    void ChangeColour()
    {
        Debug.Log("AHHHHHHHHH");
        materialChange.color = Color.blue;
    }
}
