using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOnScore : MonoBehaviour
{

    Transform ball;
    float ballIsPastPlayer = 14.84f;
    Camera camera;
    float targetZoom = 10f;
    float zoomOut = 0;
    float followSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.x > ballIsPastPlayer)
        {
            SetCameraSize();
        }
        else if (ball.position.x < -ballIsPastPlayer)
        {
            SetCameraSize();
        }
        else
        {
            if (camera.orthographicSize >= 10) return;

            zoomOut += 0.1f;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoomOut, Time.deltaTime);
            camera.transform.position = new Vector3(0, 0, -10);
        }
    }

    void SetCameraSize()
    {
        if (camera.orthographicSize > 0)
        {
            camera.transform.position = new Vector3(Mathf.Lerp(camera.transform.position.x, ball.position.x, Time.deltaTime * followSpeed), Mathf.Lerp(camera.transform.position.y, ball.position.y, Time.deltaTime * followSpeed), -10);
            targetZoom -= 0.1f;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime);
        }
    }
}
