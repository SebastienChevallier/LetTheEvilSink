using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    CreatureStateManager creature;


    void Start()
    {
        creature = GameObject.FindWithTag("Creature").GetComponent<CreatureStateManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpawnPoint") || collision.gameObject.CompareTag("Door") || collision.gameObject.CompareTag("Deplacer"))
        {
            if (creature.currentState == creature.SearchState)
                creature.SearchState.OnCollisionEnter(creature, collision);
            else if (creature.currentState == creature.ChaseState)
                creature.ChaseState.OnCollisionEnter(creature, collision);
        }
    }
}
