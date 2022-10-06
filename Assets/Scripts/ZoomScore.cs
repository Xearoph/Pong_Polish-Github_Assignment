using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScore : MonoBehaviour
{
    GameObject ball;
    Camera thiscamera;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        thiscamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        MoveCamera(ball.transform.position);
    }

    void MoveCamera(Vector3 transformation)
    {
        thiscamera.transform.position = Vector3.MoveTowards(transform.position, transformation, .001f * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
