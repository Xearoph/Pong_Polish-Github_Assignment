using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScore : MonoBehaviour
{
    GameObject ball;
    Camera thisCamera;
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
        float target = 0f;
        while (thisCamera.orthographicSize >= 4f)
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
    }
}
