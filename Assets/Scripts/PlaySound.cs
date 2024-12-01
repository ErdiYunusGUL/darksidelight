using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

   public void PlayEffect()
    {
        audioSource.PlayOneShot(soundEffect);
    }
}
