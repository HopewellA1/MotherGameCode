using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisionSounds : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component on the snake object
   // public AudioSource audioSourceEnd; // Reference to the AudioSource component on the snake object
    public AudioClip eatSound; // Assign the AudioClip for the eat sound effect
    //public AudioClip spikeSound; // Assign the AudioClip for the eat sound effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Sphere" || other.gameObject.name == "NoCount")
        {
            // Play the sound effect
            audioSource.PlayOneShot(eatSound);

          
        }
     
    }
}
