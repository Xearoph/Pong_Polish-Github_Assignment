using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddZoomScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ball;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        ball.AddComponent<ZoomScore>();
    }
}
