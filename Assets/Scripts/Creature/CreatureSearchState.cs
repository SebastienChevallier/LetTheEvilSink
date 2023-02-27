using UnityEngine;

public class CreatureSearchState : CreatureBaseState
{
    Vector3 lastPositionHeard;
    Vector3 lastPlayerPosition;

    public bool soundHeard = false;
    public bool positionChecked = false;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load resources
        creature.currentStateName = "Search State";
        creature.agent.speed = creature.searchSpeed;

        // Spawn Creature
        SpawnCreature(creature);
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        CreatureVisualDetection(creature);

        // Movement patterns
        if (positionChecked)
        {
            if (!soundHeard)
            {
                WanderInRoom(creature);
            }
            else
                CheckHeardSoundPosition(creature);
        }
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Makes the creature disappear when it reaches a door
        if (collision.gameObject.CompareTag("Door"))
        {
            ResetState(creature);
            creature.AddGauge(-creature.searchGaugeDiminution);
            creature.summoned = false;
            Object.Destroy(creature.enemy.gameObject);
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        else if (collision.gameObject.CompareTag("Deplacer"))
        {
            Object.Destroy(collision.gameObject);
        }
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // Set destination where creature heard a sound
        if (other.CompareTag("StepSound"))
        {
            lastPositionHeard = creature.player.position;
            soundHeard = true;
        }
    }

    void SpawnCreature(CreatureStateManager creature)
    {
        // Calculate spawn point
        Transform spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;

        // Set creature Transform
        ///

        // Swpawn creature
        creature.summoned = true;

        // Make creature check last player position
        lastPlayerPosition = creature.player.position;
        CheckLastPlayerPosition(creature);
    }

    void WanderInRoom(CreatureStateManager creature)
    {
        // Chase player desperately
        creature.agent.SetDestination(creature.player.position);
    }

    void CheckLastPlayerPosition(CreatureStateManager creature)
    {
        // Make creature move to last player position
        creature.agent.SetDestination(lastPlayerPosition);

        if (creature.enemy.position == lastPlayerPosition)
        {
            positionChecked = false;
        }
    }


    void CheckHeardSoundPosition(CreatureStateManager creature)
    {
        // Make the creature check where it heard a sound
        creature.agent.SetDestination(lastPositionHeard);

        if (creature.enemy.position == lastPositionHeard)
        {
            soundHeard = false;
        }
    }

    void CreatureVisualDetection(CreatureStateManager creature)
    {
        // Switch to chase mode if creature gets close enough to player
        if (creature.so_player._InDark)
        {
            if (Vector3.Distance(creature.player.position, creature.enemy.position) <= creature.visionDetectionInDark)
            {
                ResetState(creature);
                creature.playerDetected = true;
                creature.SwitchState(creature.ChaseState);
            }
        }
        else
        {
            if (Vector3.Distance(creature.player.position, creature.enemy.position) <= creature.visionDetectionInLight)
            {
                ResetState(creature);
                creature.playerDetected = true;
                creature.SwitchState(creature.ChaseState);
            }
        }
    }

    void ResetState(CreatureStateManager creature)
    {
        // Reset all variables for next instance of this state
        creature.backFromChaseMode = false;
        soundHeard = false;
        positionChecked = false;

}
}