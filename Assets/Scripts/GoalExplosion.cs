using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoalExplosion : MonoBehaviour
{

    GameObject objToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        objToSpawn = new GameObject("particlesystem");
        objToSpawn.AddComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundleft" || collision.gameObject.tag == "BoundRight")
        {
            
        }
    }
}
