using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayback : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.CompareTag("Player")) 
		{
            audioSource.Play();    
		}
    }
}