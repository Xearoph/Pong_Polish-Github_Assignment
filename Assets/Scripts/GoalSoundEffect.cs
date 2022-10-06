using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Writen by Luuk
public class GoalSoundEffect : MonoBehaviour
{
    private AudioSource audioS;
    private GameObject player;
    private float volume = 0.6f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Add temporary audiosource component
        audioS = gameObject.AddComponent<AudioSource>();

        if(!player.TryGetComponent<GoalSoundEffect>(out _))
        {
            player.AddComponent<GoalSoundEffect>();
        }

        //Load the audioclip from the resource map
        //Change the volume of the temporary audiosource
        audioS.volume = volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioS.clip = Resources.Load<AudioClip>("Audio/GoalSoundEffect");

        if (collision.gameObject.tag == "BoundLeft" || collision.gameObject.tag == "BoundRight")
        {
            audioS.Play();
        }
    }
}
