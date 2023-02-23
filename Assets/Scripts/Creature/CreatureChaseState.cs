using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    public override void EnterState(CreatureStateManager creature)
    {
        // Load Resources
        creature.so_creature.currentState = "Chase State";
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        LostPlayer(creature);
    }

    public override void FixedUpdateState(CreatureStateManager creature)
    {
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
        creature.enemy.position = Vector3.MoveTowards(creature.enemy.position, creature.player.position, creature.so_creature.chaseSpeed * Time.fixedDeltaTime);
    }

    void LostPlayer(CreatureStateManager creature)
    {
        // Creature loses sight of player when too far
        if (Mathf.Abs(creature.player.position.x - creature.enemy.position.x) >= creature.so_creature.chaseDistance)
        {
            creature.so_creature.apparitionTimer = 0;
            creature.so_creature.playerDetected = false;
            creature.so_creature.backFromChaseMode = true;
            creature.SwitchState(creature.SearchState);
        }
    }

    void ResetState(CreatureStateManager creature)
    {
        // Reset all variables for next instance of this state
        creature.so_creature.gauge = 0;
        creature.so_creature.summoned = false;
        creature.so_creature.playerDetected = false;
    }
}