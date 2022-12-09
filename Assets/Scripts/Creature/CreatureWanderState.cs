using UnityEngine;

public class CreatureWanderState : CreatureBaseState
{
    So_Creature so;

    public Transform playerStartPosition;

    float timeDelay = 10f;
    float timeLeft;
    float smoothTimer = 2f;
    int gaugeDiminution = 1;


    public override void EnterState(CreatureStateManager creature)
    {
        // Load scriptable data
        so = Resources.Load<So_Creature>("Creature/SO_Creature");
        so.currentState = "Wander State";

        // Save variables
        playerStartPosition = GameObject.FindWithTag("Player").transform;
        timeLeft = timeDelay;
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        LowerGauge();

        // Switch to search state when player did too much shit
        if (so.gauge >= 100)
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

    void LowerGauge()
    {
        // Lower gauge every second
        timeLeft -= Time.fixedDeltaTime * smoothTimer;
        if (timeLeft < 0 && !so.summoned)
        {
            so.AddGauge(-gaugeDiminution);
            timeLeft = timeDelay;
        }
    }
}
