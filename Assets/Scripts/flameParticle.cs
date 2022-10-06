using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameParticle : MonoBehaviour
{
    // variable that can only be accessed in this class
    private GameObject ballObject;


    // Start is called before the first frame update
    void Start()
    {
        // finds the object with the tag Player
        ballObject = GameObject.FindWithTag("Player");
        //adds a component to the object with the tag
        ballObject.AddComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // material color of the trail
        ballObject.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", Color.red);
        // the time duration of the trail
        ballObject.GetComponent<TrailRenderer>().time = 0.4f;
        // the start width of the trail
        ballObject.GetComponent<TrailRenderer>().startWidth = 0.6f;
        // the end width of the trail
        ballObject.GetComponent<TrailRenderer>().endWidth = 0.1f;
    }
}
