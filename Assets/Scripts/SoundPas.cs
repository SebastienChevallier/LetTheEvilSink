using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPas : MonoBehaviour
{
    public AudioSource _AudioSource;

    public So_Player _PlayerData;

    public List<AudioClip> _Pas;

    public void PlaySound()
    {
        int rand = Random.Range(0, _Pas.Count);
        AudioClip clip = _Pas[rand];
        _AudioSource.PlayOneShot(clip);
    }

    public void StepSound(float duration)
    {
        Player_Movements.Instance.SonDePas(duration);
    }
}
