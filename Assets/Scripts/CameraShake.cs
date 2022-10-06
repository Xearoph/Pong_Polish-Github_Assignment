using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // the higher the shakepower the more intense.
    public float shakePower = 1f;
    //the higher the shakelength the longer it lasts.
    public float shakeLength = 1f;
    // put camera on here.
    public Transform camera;
    // boolean to check if its still shaking or not.
    public bool isShaking = false;

    Vector2 cameraStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        // save the camera's startposition.
        cameraStartPosition = camera.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            // calculate random values for the x & y axis.
            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;
            camera.transform.position = new Vector2(x, y);
        }
        else
        {
            isShaking = false;
            shakeLength = 1;

        }
    }
}
