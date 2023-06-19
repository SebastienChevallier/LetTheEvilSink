using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PosProcessModifier : MonoSingleton<PosProcessModifier>
{
    public Volume _Volume;
    public So_Player _PlayerData;
    public So_Parametres _Parametres;
    
    private CameraBehavior _Camera;
    private float _Zoom;
    private ChromaticAberration _CA;
    private Vignette _VG;
    private FilmGrain _FG;
    private ShadowsMidtonesHighlights _SMH;
    private LensDistortion _LD;
    private ColorCurves _colorCurves;

    private void Awake()
    {
        _Camera = GameObject.Find("ArmCamera").GetComponent<CameraBehavior>();
        //_Zoom = _Camera._ZoomValue;
        
        _Volume.profile.TryGet(out _CA);
        _Volume.profile.TryGet(out _VG);
        _Volume.profile.TryGet( out _FG);
        _Volume.profile.TryGet(out _SMH);
        _Volume.profile.TryGet(out _LD);
        _Volume.profile.TryGet(out _colorCurves);
    }

    private void Update()
    {
        ChromaticChange(_PlayerData._ValAngoisse);
        //_SMH.shadows.value = new Vector4(0,0,_Parametres.brightness,0);
        if (Input.GetKey(KeyCode.A)) StartCoroutine(LensDistortion(100,1));
    }

    public void ChromaticChange(float value)
    {        
        //_Camera._ZoomValue = Mathf.Clamp(_Zoom * (1 - (value / 100)), 2, 10);
        _CA.intensity.value = Mathf.Clamp((value) / 100, 0f, 1f);
        _VG.intensity.value = Mathf.Clamp((value) / 200, 0f, 1f);
        _FG.intensity.value = Mathf.Clamp((value) / 100, 0f, 1f);
    }

    public void FlashChromaticAberation(float time, float intensity)
    {
        StartCoroutine(Flash(time, intensity));
        StartCoroutine(VigneteLerp(time * 30, intensity));
    }
    
    IEnumerator VigneteLerp(float time, float intensity)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _VG.intensity.value = Mathf.Lerp(intensity/2.5f, (_PlayerData._ValAngoisse) / 200, timer / time);
            _FG.intensity.value = Mathf.Lerp(intensity, (_PlayerData._ValAngoisse) / 100, timer / time);
            yield return null;
        }
    }
    
    IEnumerator Flash(float time, float intensity)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _CA.intensity.value = Mathf.Lerp(0, intensity, timer / time);
            yield return null;
        }
    }

    IEnumerator LensDistortion(float time, float intensity)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            float x = 0;
            float y = 0;
            
            x = Mathf.Lerp(x,Random.Range(-intensity, intensity),timer/time);
            y = Mathf.Lerp(y,Random.Range(-intensity, intensity), timer/time);

            _LD.center = new Vector2Parameter(new Vector2(x,y), true);
            _LD.xMultiplier = new ClampedFloatParameter(x,0, intensity, true);
            _LD.yMultiplier = new ClampedFloatParameter(y,0, intensity, true);
            yield return null;
        }
    }
    
    
   
}
