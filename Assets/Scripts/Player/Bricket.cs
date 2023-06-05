using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bricket : MonoBehaviour
{
    public GameObject _LampeTorche;
    public So_Player _PlayerData;
    public CreatureStateManager _creature;
    public ParticleSystem _particleSystem;
    public SoundPas ScriptSound;
    public GameObject apparition;
    
    public float apparitionRate = 0.1f;
    
    public float FailRate = 0f;
    public float addFailRateValue = 0.05f;
    public float maxFailRate = 0.75f;
    
    public void Start()
    {       
        _creature = FindObjectOfType<CreatureStateManager>();
    }

    public void Update()
    {
        LampeTorche();
    }

    void LampeTorche()
    {
        if (Input.GetButtonDown("LampeTorche") && _PlayerData._CanMove)
        {
            if(_creature != null)
                _creature.AddGauge(5);
            
            if(FailRate < maxFailRate)
                FailRate += addFailRateValue;

            float random = Random.Range(0f, 1f);

            if (_PlayerData._CanLight)
            {
                if (_PlayerData._CanMove) ScriptSound.PlaySound();

                if (random > FailRate)
                {
                    _PlayerData._InDark = false;
                    _PlayerData._CanLight = false;
                    _LampeTorche.SetActive(true);
                }
                else
                {
                    //Spawn FX Light Fail
                    random = Random.Range(0f, 1f);
                    if (random < apparitionRate)
                    {
                        PosProcessModifier.Instance.FlashChromaticAberation(0.1f,1f);
                        StartCoroutine(Apparition(0.1f));
                    }
                    
                    _particleSystem.Play();
                }
            }
            else
            {
                _PlayerData._InDark = true;
                _PlayerData._CanLight = true;
                _LampeTorche.SetActive(false);
            }
        }
    }
    
    IEnumerator Apparition(float time)
    {
        apparition.SetActive(true);
        yield return new WaitForSeconds(time);
        apparition.SetActive(false);
    }
}
