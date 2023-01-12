using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrea : MonoBehaviour
{
    public So_Creature _creature;
    private void OnTriggerStay(Collider other)
    {
        _creature.AddGauge(1);
    }
}
