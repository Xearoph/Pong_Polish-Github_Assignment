using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameParticle : MonoBehaviour
{
    private GameObject ballObject;
    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Player");
        ballObject.AddComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
