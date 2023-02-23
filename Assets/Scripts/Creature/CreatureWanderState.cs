using UnityEngine;

public class CreatureWanderState : CreatureBaseState
{
    float timeDelay = 10f;
    float timeLeft;
    float smoothTimer = 2f;
    int gaugeDiminution = 1;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load scriptable data
        creature.so_creature.currentState = "Wander State";

        // Save variables
        creature.player = GameObject.FindWithTag("Player").transform;
        timeLeft = timeDelay;
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        LowerGauge(creature);

        // Switch to search state when player did too much shit
        if (creature.so_creature.gauge >= 100)
            creature.SwitchState(creature.SearchState);
    }

    public override void FixedUpdateState(CreatureStateManager creature)
    {
        
    }

    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {

    }

    public override void OnTriggerEnter(CreatureStateManager creature, Collider other)
    {

    }

    void LowerGauge(CreatureStateManager creature)
    {
        // Lower gauge every second
        timeLeft -= Time.fixedDeltaTime * smoothTimer;
        if (timeLeft < 0 && !creature.so_creature.summoned)
        {
            creature.so_creature.AddGauge(-gaugeDiminution);
            timeLeft = timeDelay;
        }
    }
}
