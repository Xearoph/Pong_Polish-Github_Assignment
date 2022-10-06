using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugoPolishScript : MonoBehaviour
{
    public GameObject hugoScript;

    public AudioSource ballPlayerCollission;

    public AudioClip Paaaaarrya;
    public void Start()
    { 
        ballPlayerCollission = gameObject.AddComponent<AudioSource>();
        ballPlayerCollission.clip = Resources.Load<AudioClip>("Audio/Parry_Ball_Sound");
        ballPlayerCollission.Play();
    }















    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerLeft")
        {

        }
        else if (collision.gameObject.tag == "PlayerRight")
        {

        }
    }
}