using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Cinematiques : MonoBehaviour
{
    private enum _TriggerType
    {
        Cinematique,
        Sons,
        VFX
    };

    [SerializeField]
    private _TriggerType _Type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trigger();
        }
        
    }

    void Trigger()
    {
        switch (_Type)
        {
            case _TriggerType.Cinematique:
                Debug.Log("Cinematiques");
                break;

            case _TriggerType.Sons:
                Debug.Log("Sons");
                break;

            case _TriggerType.VFX:
                Debug.Log("VFX");
                break;

            default:
                break;
        }
    }
}
