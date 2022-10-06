using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Writen by Luuk
public class GoalSoundEffect : MonoBehaviour
{
    public GameObject wallLeft;
    public GameObject wallRight;

    private AudioSource audioS;
    public AudioClip[] goalSoundEffects;
    private float volume = 0.6f;

    private void Start()
    {
        //Create temporary component on this gameobject
        wallLeft.AddComponent<GoalSoundEffect>();
        wallRight.AddComponent<GoalSoundEffect>();

        audioS = gameObject.AddComponent<AudioSource>();
        //Set the volume of the audioSource the same as the float volume
        audioS.volume = volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the ball collide with the WallLeft or WallRight...
        if (collision.gameObject.tag == "Player")
        {
            //Get a random audioclip and play that via the audioSource
            audioS.clip = GetRandomClip();
            //Play the audioclip via the audioSource
            audioS.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        //Select a random audiofile from 0 to the amount that is selected in the inspector. And then return that file so that it can be played by the audiosource
        return goalSoundEffects[Random.Range(0, goalSoundEffects.Length)];
    }
}
