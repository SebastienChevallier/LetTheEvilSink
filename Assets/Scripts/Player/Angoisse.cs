using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angoisse : MonoBehaviour
{
    public So_Player _PlayerData;
    public So_Creature _creature;
    public float _TimeDelay = 1f;
    public float _ValUp;
    public float _ValDown;
    private float timeLeft;
    private Player_Movements _PlayerMovement;
    

    private void Start()
    {
        _PlayerMovement = GetComponent<Player_Movements>();
        
        timeLeft = _TimeDelay;
    }


    // Update is called once per frame
    void Update()
    {
        TimeAngoise();
    }

    void TimeAngoise()
    {
        if (_PlayerData._InDark)
        {
            if(timeLeft < 0 && _PlayerData._ValAngoisse >= 100)
            {
                _creature.AddGauge(1);
                timeLeft = _TimeDelay;
            }

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 && _PlayerData._ValAngoisse < 100f)
            {
                _PlayerData._ValAngoisse += _ValUp;
                timeLeft = _TimeDelay;
            }
        }else
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 && _PlayerData._ValAngoisse > 0f)
            {
                _PlayerData._ValAngoisse -= _ValDown;
                timeLeft = _TimeDelay;
            }
        }       
    }
}
