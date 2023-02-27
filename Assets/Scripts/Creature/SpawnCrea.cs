using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrea : MonoBehaviour
{
    public CreatureStateManager _creature;

    private void Start()
    {
        _creature = FindObjectOfType<CreatureStateManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        _creature.AddGauge(1);
    }
}
