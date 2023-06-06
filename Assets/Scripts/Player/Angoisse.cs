 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angoisse : MonoBehaviour
{
    public So_Player _PlayerData;
    public CreatureStateManager _creature;
    public float _TimeDelay = 1f;
    public float _ValUp;
    public float _ValDown;
    private float timeLeft;
    private Player_Movements _PlayerMovement;
    

    private void Start()
    {
        _PlayerMovement = GetComponent<Player_Movements>();
        _creature = FindObjectOfType<CreatureStateManager>();

        timeLeft = _TimeDelay;
    }


    // Update is called once per frame
    void Update()
    {
        TimeAngoise();
    }

    void TimeAngoise()
    {
        timeLeft -= Time.deltaTime;

        if (_PlayerData._InDark)
        {
            if (timeLeft < 0 && _PlayerData._ValAngoisse >= 100)
            {
                timeLeft = _TimeDelay;
            }

            if (timeLeft < 0 && _PlayerData._ValAngoisse < 100f)
            {
                _PlayerData._ValAngoisse += _ValUp;
                timeLeft = _TimeDelay;
            }
        }
        else
        {
            if (timeLeft < 0 && _PlayerData._ValAngoisse > 0f)
            {
                _PlayerData._ValAngoisse -= _ValDown;
                timeLeft = _TimeDelay;
            }
        }       
    }
}
