using UnityEngine;

public class CreatureChaseState : CreatureBaseState
{
    So_Creature so_enemy;
    GameObject enemy;
    Transform enemyVisuals;

    Transform player;


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
        ChasePlayer();
        FlipCreature();
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        // Destroy obstacles that the player may have placed
        if (collision.gameObject.CompareTag("Deplacer"))
            Object.Destroy(collision.gameObject);
    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {
        // If player gets caught, reset position to start and switch creature to wander mode
        if (other.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            player.position = creature.WanderState.playerStartPosition.position;
            creature.SwitchState(creature.WanderState);
        }
    }

    void ChasePlayer()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.position, so_enemy.chaseSpeed * Time.fixedDeltaTime);
    }

    void FlipCreature()
    {
        //Flip creature to make it face the player when moving
        if (enemy.transform.position.x > player.position.x)
            enemyVisuals.localScale = new Vector3(1, 1, 1);
        else
            enemyVisuals.localScale = new Vector3(-1, 1, 1);
    }
}
