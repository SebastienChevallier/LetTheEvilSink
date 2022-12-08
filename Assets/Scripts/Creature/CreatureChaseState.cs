using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    So_Creature so_enemy;
    GameObject enemy;
    Transform enemyVisuals;

    Transform player;

    float smoothTimer = 0.2f;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load Resources
        so_enemy = Resources.Load<So_Creature>("Creature/SO_Creature");
        so_enemy.currentState = "Chase State";
        enemy = GameObject.FindWithTag("Creature");
        enemyVisuals = enemy.transform.GetChild(0);
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        LostPlayer();
    }

    public override void FixedUpdateState(CreatureStateManager creature)
    {
        CreatureMovement();
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // If player gets caught, reset position to start and switch creature to wander mode
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetState();
            player.position = creature.WanderState.playerStartPosition.position;
            creature.SwitchState(creature.WanderState);
        }
        // Destroy obstacles that the player may have placed
        if (collision.gameObject.CompareTag("Deplacer"))
            Object.Destroy(collision.gameObject);
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // Checks if player is hided (doesn't matter in this mode)
        if (other.CompareTag("Player"))
        {
            ResetState();
            player.position = creature.WanderState.playerStartPosition.position;
            creature.SwitchState(creature.WanderState);
        }
    }

    void CreatureMovement()
    {
        // Chase player desperately
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.position, so_enemy.chaseSpeed * Time.fixedDeltaTime);

        //Flip creature to make it face the player when moving
        if (enemy.transform.position.x > player.position.x)
            enemyVisuals.localScale = new Vector3(1, 1, 1);
        else
            enemyVisuals.localScale = new Vector3(-1, 1, 1);
    }

    void LostPlayer()
    {
        // Make creature walk away after the wander timer
        so_enemy.chaseTimer -= Time.fixedDeltaTime * smoothTimer;

        if (so_enemy.chaseTimer <= 0f || Mathf.Abs(player.position.x - enemy.transform.position.x) >= so_enemy.chaseDistance)
        {
            
        }
    }

    void ResetState()
    {
        // Reset all variables for next instance of this state
        so_enemy.gauge = 0;
        so_enemy.chaseTimer = so_enemy.maxChaseTimer;
        so_enemy.summoned = false;
        so_enemy.playerDetected = false;
        Object.Destroy(enemy);
    }
}
