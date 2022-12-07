using System.Collections;
using UnityEngine;

public class CreatureSearchState : CreatureBaseState
{
    So_Creature so_enemy;
    GameObject enemy;
    Transform enemyVisuals;

    Transform player;
    So_Player so_player;

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
        so_enemy = Resources.Load<So_Creature>("Creature/SO_Creature");
        player = GameObject.FindWithTag("Player").transform;
        so_player = player.GetComponent<Player_Movements>()._PlayerData;
        room = GameObject.FindWithTag("Room").transform;

        SpawnCreature();
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        // /!\ Make the creature react to player sound /!\

        // Movement patterns
        if (!searchFinished)
            CheckLastPlayerPosition();
        else if (searchFinished)
            WanderInRoom();

        WanderTimer();
        CreatureVisualDetection(creature);
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Make the creature disappear when it reaches a door
        if (collision.gameObject.CompareTag("SpawnPoint") || collision.gameObject.CompareTag("Door"))
        {
            so_enemy.gauge -= gaugeDiminution;
            so_enemy.apparitionTimer = so_enemy.maxApparationTimer;
            so_enemy.wanderTimer = so_enemy.maxWanderTimer;
            firstRoundFinished = false;
            searchFinished = false;
            walkAway = false;
            so_enemy.summoned = false;
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
        enemyVisuals = enemy.transform.GetChild(0);
        so_enemy.summoned = true;

        //Set destinations for creature check
        firstPosition = enemy.transform.position.x > player.position.x ? new Vector3(player.position.x - searchOffset, enemy.transform.position.y, enemy.transform.position.z) : new Vector3(player.position.x + searchOffset, enemy.transform.position.y, enemy.transform.position.z);
        secondPosition = enemy.transform.position.x > player.position.x ? new Vector3(player.position.x + searchOffset, enemy.transform.position.y, enemy.transform.position.z) : new Vector3(player.position.x - searchOffset, enemy.transform.position.y, enemy.transform.position.z);
        targetPosition = firstPosition;
    }

    void CheckLastPlayerPosition()
    {
        // Make creature move to last player position and check around
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, so_enemy.speed * Time.fixedDeltaTime);

        if (enemy.transform.position.x <= firstPosition.x)
        {
            targetPosition = secondPosition;
            FlipCreature(targetPosition);
            firstRoundFinished = true;
        }
        else if (enemy.transform.position.x >= secondPosition.x && firstRoundFinished)
        {
            randomPosition = new Vector3(enemy.transform.position.x + Random.Range(-room.localScale.x / so_enemy.roomRatioForWander, room.localScale.x / so_enemy.roomRatioForWander), enemy.transform.position.y, enemy.transform.position.z);
            FlipCreature(randomPosition);
            searchFinished = true;
        }
    }

    void WanderInRoom()
    {
        // Make creature wander with a new positions every X seconds
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, randomPosition, so_enemy.speed * Time.fixedDeltaTime);

        so_enemy.wanderTimer -= Time.fixedDeltaTime * smoothTimer;
        if (so_enemy.wanderTimer <= 0f && !walkAway)
        {
            randomPosition = new Vector3(enemy.transform.position.x + Random.Range(-room.localScale.x / so_enemy.roomRatioForWander, room.localScale.x / so_enemy.roomRatioForWander), enemy.transform.position.y, enemy.transform.position.z);
            FlipCreature(randomPosition);
            so_enemy.wanderTimer = so_enemy.maxWanderTimer;
        }
    }

    void WanderTimer()
    {
        // Make creature walk away after the wander timer
        so_enemy.apparitionTimer -= Time.fixedDeltaTime * smoothTimer;
        if (so_enemy.apparitionTimer <= 0f)
        {
            randomPosition = new Vector3(spawnPoint.position.x, enemy.transform.position.y, enemy.transform.position.z);
            FlipCreature(randomPosition);
            walkAway = true;
        }
    }

    void FlipCreature(Vector3 destination)
    {
        //Flip creature to make it face the player when moving
        if (enemy.transform.position.x > destination.x)
        {
            enemyVisuals.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            enemyVisuals.localScale = new Vector3(-1, 1, 1);
        }
    }

    void CreatureVisualDetection(CreatureStateManager creature)
    {
        // Switch to chase mode if creature gets close enough to player
        if (so_player._InDark)
        {
            if (Mathf.Abs(player.position.x - enemy.transform.position.x) <= so_enemy.visionRadiusDark)
            {
                so_enemy.playerDetected = true;
                Debug.Log("DARK CHASE MODE");
                creature.SwitchState(creature.ChaseState);
            }
        }
        else
        {
            if (Mathf.Abs(player.position.x - enemy.transform.position.x) <= so_enemy.visionRadiusLight)
            {
                so_enemy.playerDetected = true;
                Debug.Log("LIGHT CHASE MODE");
                creature.SwitchState(creature.ChaseState);
            }
        }
    }
}

