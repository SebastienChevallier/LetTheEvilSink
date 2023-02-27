using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public CreatureStateManager creature;
    public Player_Movements player;

    private void Start()
    {
        //creature = GameObject.FindWithTag("CreatureManager").GetComponent<CreatureStateManager>();
        //player = GameObject.FindWithTag("Player").GetComponent<Player_Movements>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ResetScene();
        }
    }

    void ResetScene()
    {
        player.InitPlayer();
        player.transform.position = GameObject.FindWithTag("CheckPoint").transform.position;
        creature.summoned = false;
        creature.playerDetected = false;
        creature.backFromChaseMode = false;
        creature.SearchState.soundHeard = false;
        creature.SearchState.positionChecked = false;
    }
}
