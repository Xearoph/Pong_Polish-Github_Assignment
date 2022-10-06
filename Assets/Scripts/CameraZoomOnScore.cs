using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOnScore : MonoBehaviour
{

    Transform ball;
    float ballIsPastPlayer = 14.84f;
    Camera camera;
    float zoomSpeed = 50f;
    float targetZoom = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camera = FindObjectOfType<Camera>();
        Debug.Log(camera.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.position.x > ballIsPastPlayer)
        {
            SetCameraSize();
        }
        else if(ball.position.x < -ballIsPastPlayer)
        {
            SetCameraSize();
        }
    }

    void SetCameraSize()
    {
        if (camera.orthographicSize > 0)
        {
            targetZoom -= 1f;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime);
        }
        
    }
}
