using UnityEngine;
using UnityEngine.AI;

public class CreatureStateManager : MonoBehaviour
{
    [Header("States")]
    public CreatureBaseState currentState;
    public CreatureWanderState WanderState = new CreatureWanderState();
    public CreatureSearchState SearchState = new CreatureSearchState();
    public CreatureChaseState ChaseState = new CreatureChaseState();

    [Header("Characters")]
    public So_Player so_player;
    [HideInInspector] public Transform player;
    public So_Creature so_creature;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public NavMeshAgent agent;

    [Header("Wander State")]
    public float wanderTimeDelay = 10f;
    public int wanderGaugeDiminution = 1;

    [Header("Search State")]
    public int searchGaugeDiminution = 25;
    public bool playerDetected;

    [Header("Chase State")]
    public bool backFromChaseMode;




    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = transform;
        agent = enemy.GetComponent<NavMeshAgent>();

        currentState = WanderState;
        currentState.EnterState(this);
    }

    void Update()
    { 
        currentState.UpdateState(this);
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
