using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Creature", menuName = "Creature", order = 1)]
public class So_Creature : ScriptableObject
{
    [Header("Jauge")]

    [Range(0, 100)]
    public int gauge;

    [Header("Parametres")]

    public float speed;
    public float visionRadius;
    public float hearingRadius;
    public float roomRatioForWander;
    public float maxApparationTimer;
    public float apparitionTimer;
    public float maxWanderTimer;
    public float wanderTimer;

    [Header("Autre")]

    public bool summoned;
    public bool canSeePlayer;

    private void OnEnable()
    {
        apparitionTimer = maxApparationTimer;
        wanderTimer = maxWanderTimer;
        summoned = false;
        canSeePlayer = false;
    }
}
