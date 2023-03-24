using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFonction : MonoBehaviour
{
    public GameObject _Essentials;

    private void Awake()
    {
        //_Essentials = GameObject.Find("Essentials");
        
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
}
