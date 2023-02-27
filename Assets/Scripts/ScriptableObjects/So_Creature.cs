using UnityEngine;

[CreateAssetMenu(fileName = "SO_Creature", menuName = "Creature", order = 1)]
public class So_Creature : ScriptableObject
{
    [Header("Etat")]
    public string currentState;
    [Range(0, 100)]
    public int gauge;
    public bool summoned;

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
    public float chaseDistance;


    private void OnEnable()
    {
        // Reset variables after use
        apparitionTimer = maxApparationTimer;
        wanderTimer = maxWanderTimer;
        summoned = false;
    }

    public void AddGauge(int value)
    {
        gauge += value;

        if (gauge > 100) gauge = 100;
        else if (gauge < 0) gauge = 0;
    }
}
