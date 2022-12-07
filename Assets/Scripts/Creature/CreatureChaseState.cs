using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    So_Creature so_enemy;
    GameObject enemy;
    Transform enemyVisuals;

    Transform player;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load Resources
        so_enemy = Resources.Load<So_Creature>("Creature/SO_Creature");
        so_enemy.currentState = "Chase state";
        enemy = GameObject.FindWithTag("Creature");
        enemyVisuals = enemy.transform.GetChild(0);
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void UpdateState(CreatureStateManager creature)
    {

    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {

    }
}
