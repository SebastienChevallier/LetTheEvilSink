using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureColliderManager : MonoBehaviour
{
    CreatureStateManager creature;


    void Start()
    {
        creature = GameObject.FindWithTag("CreatureManager").GetComponent<CreatureStateManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Trigger state colliders
        if (creature.currentState == creature.SearchState)
            creature.SearchState.OnCollisionEnter(creature, collision);
        else if (creature.currentState == creature.ChaseState)
            creature.ChaseState.OnCollisionEnter(creature, collision);
    }

    void OnTriggerEnter(Collider other)
    {
        // Trigger state colliders
        if (creature.currentState == creature.SearchState)
            creature.SearchState.OnTriggerEnter(creature, other);
        else if (creature.currentState == creature.ChaseState)
            creature.ChaseState.OnTriggerEnter(creature, other);
    }
}
