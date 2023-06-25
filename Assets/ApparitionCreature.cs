using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionCreature : MonoBehaviour
{
    private CreatureStateManager creature;
    public Transform playerSpawnPoint;
    public Transform creatureSpawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            creature.agent.Warp(creatureSpawnPoints.position);
            creature.SwitchState(creature.ChaseState);
            Player_Movements.Instance.transform.position = playerSpawnPoint.position;
        }
    }
}
