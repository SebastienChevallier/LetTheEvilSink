using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float flickPower;
    public float delayFlick;
    private float delay;
    
    private Light _light;
    private float _initialIntensity;
    private float _initialRange;
    
    private void Start()
    {
        _light = GetComponent<Light>();
        _initialIntensity = _light.intensity;
        _initialRange = _light.range;
        delay = Time.time + delayFlick;
    }
    
    private void Update()
    {
        if(Time.time > delay)
            Flickering();
    }
    
    private void Flickering()
    {
        _light.intensity = Random.Range(_initialIntensity - flickPower, _initialIntensity + flickPower);
        _light.range = Random.Range(_initialRange - flickPower, _initialRange + flickPower);
        delay = Time.time + delayFlick;
    }
}
