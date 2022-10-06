using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hoi");
        if (collision.gameObject.CompareTag("BoundLeft"))
        {
            Debug.Log("jeej");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
