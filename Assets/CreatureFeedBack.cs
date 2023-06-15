using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureFeedBack : MonoBehaviour
{
    public CreatureStateManager creature;

    public CamShake CamShake;

    public float shakeAmount;
    public float shakeDuration;
    public float decreaseFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        creature = CreatureStateManager.Instance;
        CamShake = CamShake.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (creature.summoned)
        {
            CamShake.shakeAmount = (100 - Vector3.Distance(transform.position, creature.transform.position))/5000;
            CamShake.shakeDuration = shakeDuration;
            CamShake.decreaseFactor = decreaseFactor;
        }
    }
}
