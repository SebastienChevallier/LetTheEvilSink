using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angoisse : MonoBehaviour
{
    public So_Player _PlayerData;
    public float _TimeDelay = 1f;
    public float _ValUp;
    public float _ValDown;
    private float timeLeft;
    private Player_Movements _PlayerMovement;
    private PosProcessModifier _Modifier;

    private void Start()
    {
        _PlayerMovement = GetComponent<Player_Movements>();
        _Modifier = GetComponent<PosProcessModifier>();
        timeLeft = _TimeDelay;
    }


    // Update is called once per frame
    void Update()
    {
        TimeAngoise();
        _Modifier.ChromaticChange(_PlayerData._ValAngoisse);
    }

    void TimeAngoise()
    {
        if (_PlayerData._InDark)
        {
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
