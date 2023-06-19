using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public bool multiTrigger = false;
    public AudioClip audioClip;
    
    private bool isTriggered = false;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (multiTrigger)
            {
                _audioSource.PlayOneShot(audioClip);
            }else if (!isTriggered)
            {
                _audioSource.PlayOneShot(audioClip);
                isTriggered = true;
            }
        }
    }
}
