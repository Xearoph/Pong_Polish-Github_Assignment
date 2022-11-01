using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScore : MonoBehaviour
{   
    //camera, ball and speed declaration
    GameObject ball;
    Camera thisCamera;
    [SerializeField] private float speed = 17f;
    void Start()
    {   //asign ball and camera
        ball = GameObject.FindGameObjectWithTag("Player");
        thisCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision) //when something triggers the ball then start a coroutine
    {
        StartCoroutine(ThisCoroutine());
    }

    IEnumerator ThisCoroutine()
    {
        Quaternion standardPosition = thisCamera.transform.rotation; //standardposition is current position of the camera
        float target = 0f; //target is a float and is zero.

        for(int i = 0; i < 30; i++) //this part still has to be commented
        {
            Vector3 targetDirection = ball.transform.position - thisCamera.transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(thisCamera.transform.forward, targetDirection, singleStep, .01f);
            thisCamera.transform.rotation = Quaternion.LookRotation(newDirection);
            yield return new WaitForSecondsRealtime(.01f);
        }
        while (thisCamera.orthographicSize >= 6f)
        {
            target -= 1f;
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, target, Time.deltaTime);
            yield return new WaitForSecondsRealtime(.01f);
        }

        while (thisCamera.orthographicSize < 10f)
        {
            target += 1f;
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, target, Time.deltaTime);
            yield return new WaitForSecondsRealtime(.01f);
        }
        while (standardPosition != thisCamera.transform.rotation)
        {
            Vector3 targetDirection = ball.transform.position - thisCamera.transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(thisCamera.transform.forward, targetDirection, singleStep, .01f);
            thisCamera.transform.rotation = Quaternion.LookRotation(newDirection);
            yield return new WaitForSecondsRealtime(.01f);
        }

    }
}
