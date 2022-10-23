using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public GameObject _StepZone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Step(0.2f);
        }
    }

    public void Step(float t)
    {
        GameObject obj = Instantiate(_StepZone, transform);
        Destroy(obj, t);
    }
}
