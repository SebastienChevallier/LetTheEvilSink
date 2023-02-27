using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    public override void EnterState(CreatureStateManager creature)
    {
        // Load Resources
        creature.currentStateName = "Chase State";
        creature.agent.speed = creature.chaseSpeed;
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        LostPlayer(creature);
        CreatureMovement(creature);
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // If player gets caught, reset position to start and switch creature to wander mode
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetState(creature);
            //player.position = creature.WanderState.player.position;
            Object.Destroy(creature.enemy.gameObject);
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        if (collision.gameObject.CompareTag("Deplacer"))
            Object.Destroy(collision.gameObject);
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // Checks if player is hidden (doesn't matter in this mode)
        if (other.CompareTag("Player"))
        {
            ResetState(creature);
            //player.position = creature.WanderState.player.position;
            Object.Destroy(creature.enemy.gameObject);
            creature.SwitchState(creature.WanderState);
        }
    }

    void CreatureMovement(CreatureStateManager creature)
    {
        // Chase player desperately
        creature.agent.SetDestination(creature.player.position);
    }

    void LostPlayer(CreatureStateManager creature)
    {
        // Creature loses sight of player when too far
        if (Vector3.Distance(creature.player.position, creature.enemy.position) >= creature.chaseDistance)
        {
            creature.playerDetected = false;
            creature.backFromChaseMode = true;
            creature.SwitchState(creature.SearchState);
        }
    }

    void ResetState(CreatureStateManager creature)
    {
        // Reset all variables for next instance of this state
        creature.gauge = 0;
        creature.summoned = false;
        creature.playerDetected = false;
    }
}