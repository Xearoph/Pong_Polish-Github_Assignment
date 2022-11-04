using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoPolishScript : MonoBehaviour
{
    public AudioSource ballPlayerCollission;


    GameObject playerBalkLeft;
    GameObject playerBalkRight;

    public void Start()
    {
        playerBalkLeft = GameObject.FindGameObjectWithTag("PlayerLeft");
        playerBalkRight = GameObject.FindGameObjectWithTag("PlayerRight");

        GameObject.FindObjectOfType<HugoPolishScript>();
        if (!playerBalkLeft.TryGetComponent<HugoPolishScript>(out _))
        {
            playerBalkLeft.AddComponent<HugoPolishScript>();
        }

        if (!playerBalkRight.TryGetComponent<HugoPolishScript>(out _))
        {
            playerBalkRight.AddComponent<HugoPolishScript>();
        }


        ballPlayerCollission = gameObject.AddComponent<AudioSource>();
        ballPlayerCollission.clip = Resources.Load<AudioClip>("Audio/Parry_Ball_Sound");

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            ballPlayerCollission.Play();
        }

    }
}