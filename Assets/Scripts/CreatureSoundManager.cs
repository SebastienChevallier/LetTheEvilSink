using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseTemplate.Behaviours;

public class CreatureSoundManager : MonoSingleton<CreatureSoundManager>
{
    public AudioClip spawnCreature;
    public AudioClip breathCreature;
    public AudioSource _audioSource;

    public void SpawnCreatureSound()
    {
        _audioSource.PlayOneShot(spawnCreature);
    }

    public void breathCreatureSound()
    {
        _audioSource.PlayOneShot(breathCreature);
    }
    
}
