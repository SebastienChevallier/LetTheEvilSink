using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFonction : MonoBehaviour
{
    public GameObject _Essentials;
    public AudioSource _AudioSource;
    public Animator _Animator;

    private void Awake()
    {
        //_Essentials = GameObject.Find("Essentials");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("LampeTorche"))
        {
            _Animator.SetFloat("Speed", 100);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("LampeTorche"))
        {
            _Animator.SetFloat("Speed", 1);
        }
    }

    public void StopPlaying()
    {
        _Essentials.SetActive(true);
        gameObject.SetActive(false);
    }

    public void StartPlaying()
    {
        _Essentials.SetActive(false);
    }
    
    public void PlaySound(AudioClip clip)
    {
        _AudioSource.PlayOneShot(clip);
    }
}
