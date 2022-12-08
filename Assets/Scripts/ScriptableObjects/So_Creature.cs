using UnityEngine;

[CreateAssetMenu(fileName = "SO_Creature", menuName = "Creature", order = 1)]
public class So_Creature : ScriptableObject
{
    [Header("Etat")]

    public string currentState;
    [Range(0, 100)]
    public int gauge;

    [Header("Parametres")]

    public float searchSpeed;
    public float chaseSpeed;
    public float visionDetectionInDark;
    public float visionDetectionInLight;
    public float hearingDetection;

    [Header("Patterns")]

    public float maxApparationTimer;
    public float apparitionTimer;
    public float maxWanderTimer;
    public float wanderTimer;
    public float roomRatioForWander;
    public float maxChaseTimer;
    public float chaseTimer;

    [Header("Autre")]

    public bool summoned;
    public bool playerDetected;


    private void OnEnable()
    {
        // Reset variables after use
        apparitionTimer = maxApparationTimer;
        wanderTimer = maxWanderTimer;
        chaseTimer = maxChaseTimer;
        summoned = false;
        playerDetected = false;

        // Don't unload scriptable
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void AddGauge(int value)
    {
        gauge += value;
        if (gauge > 100)
            gauge = 100;
    }
}
