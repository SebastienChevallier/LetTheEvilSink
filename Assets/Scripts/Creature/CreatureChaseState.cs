using System.Collections;
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
            Player_Movements.Instance.RespawnPlayer();
            creature.agent.Warp(Vector3.zero);
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        if (collision.gameObject.CompareTag("Deplacer"))
        {
            Object.Destroy(collision.gameObject);
            CreatureStateManager.Instance.LaunchRal();
        }
    }

    

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // Checks if player is hidden (doesn't matter in this mode)
        if (other.CompareTag("Player"))
        {
            ResetState(creature);
            creature.player.position = CheckPointsManager.Instance.lastCheckPoint.transform.position;
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

        if (creature.panelCables.activeSelf) creature.panelCables.SetActive(false);
        foreach (GameObject go in creature.panelCarte)
        {
            if (go.activeSelf) go.SetActive(false);
        }
        foreach (GameObject go in creature.panelCrochetage)
        {
            if (go.activeSelf) go.SetActive(false);
        }
    }
}