using System.Collections;
using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.AI;

public class CreatureStateManager : MonoSingleton<CreatureStateManager>
{
    [Header("Characters")]
    public So_Player so_player;
    [HideInInspector] public Transform player;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public NavMeshAgent agent;

    [Header("States")]
    [Range(0, 100)]
    public int gauge;
    public string currentStateName;
    public CreatureBaseState currentState;
    public CreatureWanderState WanderState = new CreatureWanderState();
    public CreatureSearchState SearchState = new CreatureSearchState();
    public CreatureChaseState ChaseState = new CreatureChaseState();
    public bool creatureSpawnable;
    public bool summoned;

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
    [HideInInspector] public bool playerDetected;

    [Header("Chase State")]
    public float chaseSpeed;
    public float chaseDistance;
    [HideInInspector] public bool backFromChaseMode;

    [Header("Panels to disable")]
    public GameObject panelCables;
    public GameObject panelCarte;
    public GameObject panelCrochetage;



    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = transform;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
        currentState = WanderState;
        currentState.EnterState(this);
    }

    void Update()
    { 
        currentState.UpdateState(this);
        animator.SetFloat("Speed", agent.speed);
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

    public void DespawnCreature()
    {
        agent.Warp(Vector3.zero);
        CreatureFeedBack.Instance.StopCreatureSound();
        SwitchState(WanderState);
        summoned = false;
    }

    public void AddGauge(int value)
    {
        if (!creatureSpawnable) return;
        
        gauge += value;

        if (gauge > 100) gauge = 100;
        else if (gauge < 0) gauge = 0;
    }

    public void LaunchRal()
    {
        StartCoroutine(Ralentissement(2f));
    }
    
    IEnumerator Ralentissement(float delay)
    {
        float tempSpeed = chaseSpeed;
        chaseSpeed = tempSpeed / 2;
        yield return new WaitForSeconds(delay);
        chaseSpeed = tempSpeed;
    }
}
