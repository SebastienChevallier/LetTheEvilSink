using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreature : MonoBehaviour
{
    public So_Creature _creature;

    private void Update()
    {
        _creature.gauge = 0;
    }
}
