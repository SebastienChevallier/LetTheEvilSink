using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public GameObject _StepZone;
    public GameObject _Clone;



    public void Step(float t)
    {
        if (!_Clone)
        {
            GameObject obj = Instantiate(_StepZone, transform);
            _Clone = obj;
            Destroy(obj, t);
        }
    }
}
