using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PosProcessModifier : MonoBehaviour
{
    private Volume _Volume;
    public So_Player _PlayerData;
    public So_Parametres _Parametres;
    
    private CameraBehavior _Camera;
    private float _Zoom;
    private ChromaticAberration _CA;
    private Vignette _VG;
    private FilmGrain _FG;
    private ShadowsMidtonesHighlights _SMH;

    private void Start()
    {
        _Camera = GameObject.Find("ArmCamera").GetComponent<CameraBehavior>();
        //_Zoom = _Camera._ZoomValue;
        _Volume = GetComponent<Volume>();
        _Volume.profile.TryGet(out _CA);
        _Volume.profile.TryGet(out _VG);
        _Volume.profile.TryGet(out _FG);
        _Volume.profile.TryGet(out _SMH);
    }

    private void Update()
    {
        ChromaticChange(_PlayerData._ValAngoisse);
        _SMH.shadows.value = new Vector4(0,0,_Parametres.brightness,0);
    }

    public void ChromaticChange(float value)
    {        
        //_Camera._ZoomValue = Mathf.Clamp(_Zoom * (1 - (value / 100)), 2, 10);
        _CA.intensity.value = Mathf.Clamp((value) / 100, 0f, 1f);
        _VG.intensity.value = Mathf.Clamp((value) / 200, 0f, 1f);
        _FG.intensity.value = Mathf.Clamp((value) / 100, 0f, 1f);
    }
}
