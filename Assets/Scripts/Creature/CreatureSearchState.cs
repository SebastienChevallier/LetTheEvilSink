using System.Collections;
using UnityEngine;

public class CreatureSearchState : CreatureBaseState
{
    So_Creature so;
    GameObject enemy;
    Transform player;
    Transform room;

    Transform spawnPoint;

    Vector3 firstPosition;
    Vector3 secondPosition;
    Vector3 targetPosition;
    Vector3 randomPosition;

    bool firstRoundFinished = false;
    bool searchFinished = false;
    bool walkAway = false;

    float spawnOffset = 1f;
    float searchOffset = 2f;

    float smoothTimer = 0.2f;

    int gaugeDiminution = 25;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load resources
        so = Resources.Load<So_Creature>("Creature/SO_Creature");
        player = GameObject.FindWithTag("Player").transform;
        room = GameObject.FindWithTag("Room").transform;

        SpawnCreature();
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        // /!\ Make the creature react to player sound and light /!\

        WanderTimer();

        // Movement patterns
        if (!searchFinished)
            CheckLastPlayerPosition();
        else if (searchFinished)
            WanderInRoom();

        // Switch to chase mode if creature gets close enough to player
        if (Mathf.Abs(player.position.x - enemy.transform.position.x) <= so.visionRadius)
        {
            //so.canSeePlayer = true;
            //creature.SwitchState(creature.ChaseState);
        }
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Make the creature disappear when it reaches a door
        if (collision.gameObject.CompareTag("SpawnPoint") || collision.gameObject.CompareTag("Door"))
        {
            so.gauge -= gaugeDiminution;
            so.apparitionTimer = so.maxApparationTimer;
            so.wanderTimer = so.maxWanderTimer;
            firstRoundFinished = false;
            searchFinished = false;
            walkAway = false;
            so.summoned = false;
            Object.Destroy(enemy);
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        else if (collision.gameObject.CompareTag("Deplacer"))
            Object.Destroy(collision.gameObject);
    }

    void SpawnCreature()
    {
        // Calculate spawn point
        spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        Vector3 spawnPosition = spawnPoint.position.x > player.position.x ? new Vector3(spawnPoint.position.x - spawnOffset, 1.5f, 0f) : new Vector3(spawnPoint.position.x + spawnOffset, 1.5f, 0f);

        // Swpawn creature
        enemy = GameObject.Instantiate(Resources.Load<GameObject>("Creature/Creature"), spawnPosition, Quaternion.identity, GameObject.FindWithTag("Environnement").transform) as GameObject;
        so.summoned = true;

        //Set destinations for creature check
        firstPosition = enemy.transform.position.x > player.position.x ? new Vector3(player.position.x - searchOffset, enemy.transform.position.y, enemy.transform.position.z) : new Vector3(player.position.x + searchOffset, enemy.transform.position.y, enemy.transform.position.z);
        secondPosition = enemy.transform.position.x > player.position.x ? new Vector3(player.position.x + searchOffset, enemy.transform.position.y, enemy.transform.position.z) : new Vector3(player.position.x - searchOffset, enemy.transform.position.y, enemy.transform.position.z);
        targetPosition = firstPosition;
    }

    void CheckLastPlayerPosition()
    {
        // Make creature move to last player position and check around
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, so.speed * Time.fixedDeltaTime);

        if (enemy.transform.position.x <= firstPosition.x)
        {
            targetPosition = secondPosition;
            firstRoundFinished = true;
        }
        else if (enemy.transform.position.x >= secondPosition.x && firstRoundFinished)
        {
            randomPosition = new Vector3(enemy.transform.position.x + Random.Range(-room.localScale.x / so.roomRatioForWander, room.localScale.x / so.roomRatioForWander), enemy.transform.position.y, enemy.transform.position.z);
            searchFinished = true;
        }
    }

    void WanderInRoom()
    {
        // Make creature wander with a new positions every X seconds
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, randomPosition, so.speed * Time.fixedDeltaTime);

        so.wanderTimer -= Time.fixedDeltaTime * smoothTimer;
        if (so.wanderTimer <= 0f && !walkAway)
        {
            randomPosition = new Vector3(enemy.transform.position.x + Random.Range(-room.localScale.x / so.roomRatioForWander, room.localScale.x / so.roomRatioForWander), enemy.transform.position.y, enemy.transform.position.z);
            so.wanderTimer = so.maxWanderTimer;
        }
    }

    void WanderTimer()
    {
        // Make creature walk away after the wander timer
        so.apparitionTimer -= Time.fixedDeltaTime * smoothTimer;
        if (so.apparitionTimer <= 0f)
        {
            randomPosition = new Vector3(spawnPoint.position.x, enemy.transform.position.y, enemy.transform.position.z);
            walkAway = true;
        }
    }
}

