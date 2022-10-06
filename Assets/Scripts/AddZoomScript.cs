using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddZoomScript : MonoBehaviour
{
    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {

        ball = GameObject.FindGameObjectWithTag("Player");
        ball.AddComponent<ZoomScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
