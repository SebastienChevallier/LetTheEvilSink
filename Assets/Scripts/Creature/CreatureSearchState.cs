using UnityEngine;

public class CreatureSearchState : CreatureBaseState
{
    Transform spawnPoint;

    Vector3 lastPositionHeard;

    public bool soundHeard = false;

    float spawnHeight = 2.5f;
    float spawnOffset = 2f;
    float searchOffset = 2f;
    float smoothTimer = 1f;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load resources
        creature.so_creature.currentState = "Search State";

        // Spawn Creature
        SpawnCreature(creature);
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        CreatureVisualDetection(creature);

        // Movement patterns
        if (!soundHeard) CheckLastPlayerPosition(creature);
        else CheckHeardSoundPosition(creature);
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Makes the creature disappear when it reaches a door
        if (collision.gameObject.CompareTag("Door"))
        {
            ResetState(creature);
            creature.so_creature.AddGauge(-creature.searchGaugeDiminution);
            creature.so_creature.summoned = false;
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
        spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;

        // Set creature Transform

        // Swpawn creature
        creature.so_creature.summoned = true;
    }

    void CheckLastPlayerPosition(CreatureStateManager creature)
    {
        // Make creature move to last player position and check around
        creature.agent.SetDestination(creature.player.position);
    }


    void CheckHeardSoundPosition(CreatureStateManager creature)
    {
        // Make the creature check where it heard a sound
        creature.agent.SetDestination(creature.player.position);

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
            if (Vector3.Distance(creature.player.position, creature.enemy.position) <= creature.so_creature.visionDetectionInDark)
            {
                ResetState(creature);
                creature.playerDetected = true;
                creature.SwitchState(creature.ChaseState);
            }
        }
        else
        {
            if (Vector3.Distance(creature.player.position, creature.enemy.position) <= creature.so_creature.visionDetectionInLight)
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
    }
}