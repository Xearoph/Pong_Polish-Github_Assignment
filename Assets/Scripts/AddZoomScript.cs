using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddZoomScript : MonoBehaviour
{
    private GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {

        Ball = GameObject.FindGameObjectWithTag("Player");
        Ball.AddComponent<ZoomScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
