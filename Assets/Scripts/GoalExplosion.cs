using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalExplosion : MonoBehaviour
{

    GameObject objToSpawn;
    Transform posBall;
    Transform leftPLayer;
    Transform rightPLayer;
    // Start is called before the first frame update
    void Start()
    {
        posBall = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        leftPLayer = GameObject.FindGameObjectWithTag("PlayerLeft").GetComponent<Transform>();
        rightPLayer = GameObject.FindGameObjectWithTag("PlayerRight").GetComponent<Transform>();
        objToSpawn = new GameObject("empty object");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (posBall.position.x >  rightPLayer.position.x+2)
        {
            objToSpawn.AddComponent<ParticleSystem>();
            Destroy(objToSpawn,3);
        }
        else if (posBall.position.x < leftPLayer.position.x-2)
        {
            objToSpawn.AddComponent<ParticleSystem>();
            Destroy(objToSpawn,3);
        }
        if (objToSpawn == null)
        {
            objToSpawn = new GameObject("empty object");
        }
        
    }
}

