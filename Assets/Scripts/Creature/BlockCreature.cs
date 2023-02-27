using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreature : MonoBehaviour
{
    public CreatureStateManager _creature;

    private void Start()
    {
        _creature = FindObjectOfType<CreatureStateManager>();
    }

    private void Update()
    {
        _creature.gauge = 0;
    }
}
