using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureFeedBack : MonoBehaviour
{
    [HideInInspector]public CreatureStateManager creature;
    [HideInInspector]public CamShake CamShake;

    public GameObject IndicDroit;
    public GameObject IndicGauche;

    public float shakeAmount;
    public float shakeDuration;
    public float decreaseFactor;
    public float shakePower = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        creature = CreatureStateManager.Instance;
        CamShake = CamShake.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosCreature();
        Shake();
    }

    void CheckPosCreature()
    {
        if (creature.summoned)
        {
            float xdist = creature.transform.position.x - transform.position.x;
            if (xdist > 0)
            {
                IndicDroit.SetActive(false);
                IndicGauche.SetActive(true);
            }
            else
            {
                IndicGauche.SetActive(false);
                IndicDroit.SetActive(true);
            }
        }
        else
        {
            IndicDroit.SetActive(false);
            IndicGauche.SetActive(false);
        }
    }

    public void Shake()
    {
        if (creature.summoned)
        {
            CamShake.shakeAmount = ((100 - Vector3.Distance(transform.position, creature.transform.position))/10000) * shakePower;
            CamShake.shakeDuration = shakeDuration;
            CamShake.decreaseFactor = decreaseFactor;
        }
    }
}
