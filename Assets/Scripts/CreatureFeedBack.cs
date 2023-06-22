using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;

public class CreatureFeedBack : MonoSingleton<CreatureFeedBack>
{
    [HideInInspector]public CreatureStateManager creature;
    [HideInInspector]public CamShake CamShake;

    public GameObject Indic;
    
    public AudioSource _AudioSource;
    public AudioSource _BehindSource;

    public AudioClip Breathclip;

    public float shakeAmount;
    public float shakeDuration;
    public float decreaseFactor;
    public float shakePower = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        creature = CreatureStateManager.Instance;
        CamShake = CamShake.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosCreature();
        Shake();
        PlayAmbiantCreatureSound();
    }

    public float cdAmbiantCrea;
    private float timeAmbiantCrea;
    public void PlayAmbiantCreatureSound()
    {
        timeAmbiantCrea += Time.deltaTime;
        if (timeAmbiantCrea >= cdAmbiantCrea)
        {
            if (Random.Range(15, 99) <= creature.gauge)
            {
                _BehindSource.panStereo = Random.Range(-1f, 1f);
                _BehindSource.PlayOneShot(Breathclip);
            }
                
            timeAmbiantCrea = 0;
        }
    }

    public void PlayCreatureSound()
    {
        _AudioSource.Play();
    }

    public void StopCreatureSound()
    {
        _AudioSource.Stop();
    }

    void CheckPosCreature()
    {
        if (creature.summoned)
        {
            Indic.SetActive(true);
        }
        else
        {
            Indic.SetActive(false);
        }
    }

    public void Shake()
    {
        if (creature.summoned)
        {
            CamShake.shakeAmount = ((100 - Vector3.Distance(transform.position, creature.transform.position))/10000) * shakePower;
            CamShake.shakeDuration = shakeDuration;
            CamShake.decreaseFactor = decreaseFactor;
        }
    }
}
