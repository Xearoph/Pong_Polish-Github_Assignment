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
        //the gameobject is whatever gameobject has the tag "player"
        player = GameObject.FindGameObjectWithTag("Player");

        //Add temporary audiosource component
        audioS = gameObject.AddComponent<AudioSource>();

        //If the player has no goalsoundeffect script
        if(!player.TryGetComponent<GoalSoundEffect>(out _))
        {
            //Added the goalsoundeffect script
            player.AddComponent<GoalSoundEffect>();
        }

        //Change the volume of the temporary audiosource
        audioS.volume = volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Load the audioclip from the resource map
        audioS.clip = Resources.Load<AudioClip>("Audio/GoalSoundEffect");

        //If the player collide with the wall...
        if (collision.gameObject.tag == "BoundLeft" || collision.gameObject.tag == "BoundRight")
        {
            //Play the soundeffect
            audioS.Play();
        }
    }
}
