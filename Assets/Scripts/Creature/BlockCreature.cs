using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreature : MonoBehaviour
{
    public CreatureStateManager _creature;
    public bool isSpawnable = true;

    private void Start()
    {
        _creature = FindObjectOfType<CreatureStateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _creature.creatureSpawnable = isSpawnable;
            CreatureSpawnPoints.Instance.currentSpawnPoint = transform;
            if (!isSpawnable)
            {
                _creature.DespawnCreature();
            }
        }
    }
}
