using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager instance = null;
    public static SFXManager Instance { get { return instance; } }

    //Är nog bättre om det görs om till en array om vi ska spara ljuden på det här sättet.
    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip[] scoreSounds;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        AudioClip sound = jumpSounds[UnityEngine.Random.Range(0, jumpSounds.Length)];
        audioSource.PlayOneShot(sound, 0.5f);
    }

    public void PlayDeath()
    {
        AudioClip sound = deathSounds[UnityEngine.Random.Range(0, deathSounds.Length)];
        audioSource.PlayOneShot(sound);
    }

    public void PlayScore()
    {
        AudioClip sound = scoreSounds[UnityEngine.Random.Range(0, scoreSounds.Length)];
        audioSource.PlayOneShot(sound);
    }
}
