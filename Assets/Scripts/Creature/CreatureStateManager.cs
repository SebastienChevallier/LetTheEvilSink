using UnityEngine;

public class CreatureStateManager : MonoBehaviour
{
    [Header("Etats")]
    public CreatureBaseState currentState;
    public CreatureWanderState WanderState = new CreatureWanderState();
    public CreatureSearchState SearchState = new CreatureSearchState();
    public CreatureChaseState ChaseState = new CreatureChaseState();

    [Header("SO")]
    public So_Player so_player;
    public So_Creature so_creature;

    [HideInInspector] public Transform player;
    [HideInInspector] public Transform enemy;



    void Start()
    {
        currentState = WanderState;
        currentState.EnterState(this);

        player = GameObject.FindWithTag("Player").transform;
        enemy = GameObject.FindWithTag("Creature").transform;
    }

    void Update()
    { 
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(CreatureBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
