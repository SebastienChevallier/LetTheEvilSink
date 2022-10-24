using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PosProcessModifier : MonoBehaviour
{
    private Volume _Volume;
    private ChromaticAberration _CA;
    private Vignette _VG;
    private FilmGrain _FG;

    private void Start()
    {
        _Volume = GetComponent<Volume>();
        _Volume.profile.TryGet(out _CA);
        _Volume.profile.TryGet(out _VG);
        _Volume.profile.TryGet(out _FG);
    }

    public void ChromaticChange(float value)
    {
        _CA.intensity.value = value/100;
        _VG.intensity.value = value/200;
        _FG.intensity.value = value/100;
    }
}
