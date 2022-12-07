using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject ballObject; //dit is een private variabele, dit betekent dus ook dat het niet in de inspector te zien is
    private GameObject cameraObject;
    private Vector3 cameraPosZ = new Vector3(0, 0, -10);
    private Vector3 distance = new Vector3(-0.25f, 0.25f, 0);
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.FindWithTag("MainCamera"); //zoekt naar een gameobject met de tag MainCamera en slaat deze in de variabele cameraObject op
        ballObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cameraObject.transform.position = ballObject.transform.position + cameraPosZ + distance; //veranderd de camerapositie naar die van de bal met de cameraPosZ erbij dit, cameraPosZ zorgt ervoor dat de camera op de goede z waarde blijft staan
    }
}
