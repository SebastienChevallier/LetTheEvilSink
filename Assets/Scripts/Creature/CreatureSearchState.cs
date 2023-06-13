using UnityEngine;
using UnityEngine.AI;

public class CreatureSearchState : CreatureBaseState
{
    Vector3 lastPositionHeard;
    Vector3 lastPlayerPosition;
    Vector3 randomPosition;

    public bool soundHeard = false;
    public bool positionChecked = false;

    float radius = 5f;

    float timer = 3f;
    float smoothTimer = 2f;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load resources
        creature.currentStateName = "Search State";
        creature.agent.speed = creature.searchSpeed;

        randomPosition = creature.enemy.position;

        // Spawn Creature
        if (!creature.backFromChaseMode)
            SpawnCreature(creature);
        else
            positionChecked = true;
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
            //creature.AddGauge(-creature.searchGaugeDiminution);
            creature.summoned = false;
            creature.agent.Warp(Vector3.zero);
            creature.SwitchState(creature.WanderState);
            //Debug.Log("Hello");
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
        creature.agent.Warp(spawnPoint.position);

        // Swpawn creature
        creature.summoned = true;

        // Make creature check last player position
        lastPlayerPosition = creature.player.position;
        CheckLastPlayerPosition(creature);
    }

    private Vector3 RandomPosition(CreatureStateManager creature)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += creature.enemy.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }

    void WanderInRoom(CreatureStateManager creature)
    {
        timer -= Time.fixedDeltaTime * smoothTimer;

        if (timer <= 0) randomPosition = RandomPosition(creature);

        creature.agent.SetDestination(randomPosition);
    }

    void CheckLastPlayerPosition(CreatureStateManager creature)
    {
        // Make creature move to last player position
        creature.agent.SetDestination(lastPlayerPosition);

        if (creature.enemy.position == lastPlayerPosition)
        {
            positionChecked = true;
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