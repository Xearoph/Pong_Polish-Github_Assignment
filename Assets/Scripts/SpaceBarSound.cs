using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBarSound : MonoBehaviour
{
    public AudioClip soundFX;
    public AudioSource SpaceBarSounds;

    void Start()
    {
        SpaceBarSounds = gameObject.AddComponent<AudioSource>();
        SpaceBarSounds.clip = Resources.Load("Audio/SpaceBarSound") as AudioClip;
        
    }

    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceBarSounds.Play();

        }
    }
    
}
