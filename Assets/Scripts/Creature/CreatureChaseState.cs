using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    So_Creature so_enemy;


    public override void EnterState(CreatureStateManager creature)
    {
        so_enemy = Resources.Load<So_Creature>("Creature/SO_Creature");
        so_enemy.currentState = "Chase state";
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
