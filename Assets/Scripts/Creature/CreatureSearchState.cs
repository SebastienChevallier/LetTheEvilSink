using UnityEngine;

public class CreatureSearchState : CreatureBaseState
{
    Transform room;
    Transform spawnPoint;

    Vector3 firstPosition;
    Vector3 secondPosition;
    Vector3 targetPosition;
    Vector3 randomPosition;

    public bool firstRoundFinished = false;
    public bool searchFinished = false;
    public bool walkAway = false;
    public bool soundHeard = false;

    float spawnHeight = 2.5f;
    float spawnOffset = 2f;
    float searchOffset = 2f;
    float smoothTimer = 1f;
    int gaugeDiminution = 25;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load resources
        creature.so_creature.currentState = "Search State";
        creature.player = GameObject.FindWithTag("Player").transform;
        room = GameObject.FindWithTag("Room").transform;

        if (!creature.so_creature.backFromChaseMode)
            SpawnCreature(creature);
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        CreatureVisualDetection(creature);
    }

    public override void FixedUpdateState(CreatureStateManager creature)
    {
        // Movement patterns
        if (!soundHeard)
        {
            WanderTimer(creature);

            if (!creature.so_creature.backFromChaseMode)
            {
                if (!searchFinished)
                    CheckLastPlayerPosition(creature);
                else if (searchFinished)
                    WanderInRoom(creature);
            }
        }
        else
            CheckHeardSoundPosition(creature);
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Makes the creature disappear when it reaches a door
        if (collision.gameObject.CompareTag("SpawnPoint") || collision.gameObject.CompareTag("Door"))
        {
            ResetState(creature);
            creature.so_creature.AddGauge(-gaugeDiminution);
            creature.so_creature.summoned = false;
            Object.Destroy(creature.enemy.gameObject);
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        else if (collision.gameObject.CompareTag("Deplacer"))
            Object.Destroy(collision.gameObject);
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // Set destination where creature heard a sound
        if (other.CompareTag("StepSound"))
        {
            randomPosition = new Vector3(creature.player.position.x, creature.enemy.position.y, creature.enemy.position.z);
            soundHeard = true;
        }
    }

    void SpawnCreature(CreatureStateManager creature)
    {
        // Calculate spawn point
        spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        Vector3 spawnPosition = spawnPoint.position.x > creature.player.position.x ? new Vector3(spawnPoint.position.x - spawnOffset, spawnHeight, creature.player.position.z) : new Vector3(spawnPoint.position.x + spawnOffset, spawnHeight, creature.player.position.z);

        // Swpawn creature
        creature.so_creature.summoned = true;


        //Set destinations for creature check
        firstPosition = creature.enemy.position.x > creature.player.position.x ? new Vector3(creature.player.position.x - searchOffset, creature.enemy.position.y, creature.enemy.position.z) : new Vector3(creature.player.position.x + searchOffset, creature.enemy.position.y, creature.enemy.position.z);
        secondPosition = creature.enemy.position.x > creature.player.position.x ? new Vector3(creature.player.position.x + searchOffset, creature.enemy.position.y, creature.enemy.position.z) : new Vector3(creature.player.position.x - searchOffset, creature.enemy.position.y, creature.enemy.position.z);
        targetPosition = firstPosition;
    }

    void CheckLastPlayerPosition(CreatureStateManager creature)
    {
        // Make creature move to last player position and check around
        creature.enemy.position = Vector3.MoveTowards(creature.enemy.position, targetPosition, creature.so_creature.searchSpeed * Time.fixedDeltaTime);

        if (creature.enemy.position.x <= firstPosition.x)
        {
            targetPosition = secondPosition;
            firstRoundFinished = true;
        }
        else if (creature.enemy.position.x >= secondPosition.x && firstRoundFinished)
        {
            randomPosition = new Vector3(creature.enemy.position.x + Random.Range(-room.localScale.x / creature.so_creature.roomRatioForWander, room.localScale.x / creature.so_creature.roomRatioForWander), creature.enemy.position.y, creature.enemy.position.z);
            searchFinished = true;
        }
    }

    void WanderInRoom(CreatureStateManager creature)
    {
        // Make creature wander with a new positions every X seconds
        creature.enemy.position = Vector3.MoveTowards(creature.enemy.position, randomPosition, creature.so_creature.searchSpeed * Time.fixedDeltaTime);

        creature.so_creature.wanderTimer -= Time.fixedDeltaTime * smoothTimer;
        if (creature.so_creature.wanderTimer <= 0f && !walkAway)
        {
            randomPosition = new Vector3(creature.enemy.position.x + Random.Range(-room.localScale.x / creature.so_creature.roomRatioForWander, room.localScale.x / creature.so_creature.roomRatioForWander), creature.enemy.position.y, creature.enemy.position.z);
            creature.so_creature.wanderTimer = creature.so_creature.maxWanderTimer;
        }
    }

    void CheckHeardSoundPosition(CreatureStateManager creature)
    {
        // Make the creature check where it heard a sound
        creature.enemy.position = Vector3.MoveTowards(creature.enemy.position, randomPosition, creature.so_creature.searchSpeed * Time.fixedDeltaTime);

        if (creature.enemy.position.x == randomPosition.x)
        {
            randomPosition = new Vector3(creature.enemy.position.x + Random.Range(-room.localScale.x / creature.so_creature.roomRatioForWander, room.localScale.x / creature.so_creature.roomRatioForWander), creature.enemy.position.y, creature.enemy.position.z);
            soundHeard = false;
        }
    }

    void WanderTimer(CreatureStateManager creature)
    {
        // Make creature walk away after the wander timer
        creature.so_creature.apparitionTimer -= Time.fixedDeltaTime * smoothTimer;

        if (creature.so_creature.apparitionTimer <= 0f)
        {
            randomPosition = new Vector3(spawnPoint.position.x, creature.enemy.position.y, creature.enemy.position.z);
            walkAway = true;
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
                creature.so_creature.playerDetected = true;
                creature.SwitchState(creature.ChaseState);
            }
        }
        else
        {
            if (Vector3.Distance(creature.player.position, creature.enemy.position) <= creature.so_creature.visionDetectionInLight)
            {
                ResetState(creature);
                creature.so_creature.playerDetected = true;
                creature.SwitchState(creature.ChaseState);
            }
        }
    }

    void ResetState(CreatureStateManager creature)
    {
        // Reset all variables for next instance of this state
        creature.so_creature.apparitionTimer = creature.so_creature.maxApparationTimer;
        creature.so_creature.wanderTimer = creature.so_creature.maxWanderTimer;
        creature.so_creature.backFromChaseMode = false;
        firstRoundFinished = false;
        searchFinished = false;
        walkAway = false;
        soundHeard = false;
    }
}