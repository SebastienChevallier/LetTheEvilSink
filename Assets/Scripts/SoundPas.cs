using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPas : MonoBehaviour
{
    public AudioSource _AudioSource;
    
    public List<AudioClip> _Pas;

    public void PlaySound()
    {
        int rand = Random.Range(0, _Pas.Count);
        AudioClip clip = _Pas[rand];
        _AudioSource.PlayOneShot(clip);
    }
}
