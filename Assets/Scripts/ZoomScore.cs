using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScore : MonoBehaviour
{
    GameObject ball;
    Camera thisCamera;
    private float speed = 17f;
    void Start()
    {   
        ball = GameObject.FindGameObjectWithTag("Player");
        
        thisCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ThisCoroutine());
    }

    IEnumerator ThisCoroutine()
    {
        Quaternion standardPosition = thisCamera.transform.rotation;
        float target = 0f;

        for(int i = 0; i < 30; i++) 
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
