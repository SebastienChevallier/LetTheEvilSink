using UnityEngine;
using UnityEngine.AI;

public class CreatureStateManager : MonoBehaviour
{
    [Header("Characters")]
    public So_Player so_player;
    [HideInInspector] public Transform player;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public NavMeshAgent agent;

    [Header("States")]
    public string currentStateName;
    public CreatureBaseState currentState;
    public CreatureWanderState WanderState = new CreatureWanderState();
    public CreatureSearchState SearchState = new CreatureSearchState();
    public CreatureChaseState ChaseState = new CreatureChaseState();
    public bool summoned;
    [Range(0, 100)]
    public int gauge;

    [Header("Detection")]
    public float visionDetectionInDark;
    public float visionDetectionInLight;
    public float hearingDetection;

    [Header("Wander State")]
    public float wanderGaugeDelay;
    public int wanderGaugeDiminution;

    [Header("Search State")]
    public float searchSpeed;
    public int searchGaugeDiminution;
    public bool playerDetected;

    [Header("Chase State")]
    public float chaseSpeed;
    public float chaseDistance;
    public bool backFromChaseMode;




    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = transform;
        agent = GetComponent<NavMeshAgent>();

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

    public void AddGauge(int value)
    {
        gauge += value;

        if (gauge > 100) gauge = 100;
        else if (gauge < 0) gauge = 0;
    }
}
