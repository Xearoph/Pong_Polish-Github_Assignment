using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    GameObject ball;
    public AudioSource BallCollision;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        if (!ball.TryGetComponent<CollisionSound>(out _))
        {
            Debug.Log("script added");
            ball.AddComponent<CollisionSound>();
        }

        BallCollision = gameObject.AddComponent<AudioSource>();
        BallCollision.clip = Resources.Load<AudioClip>("Audio/TokSound");

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            BallCollision.Play();
            Debug.Log("tok!");
            
        }

    }

}
    
