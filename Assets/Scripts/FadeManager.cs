using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;
using TMPro;

public class FadeManager : MonoSingleton<FadeManager>
{
    public TextMeshProUGUI _text;

    public void ChangeText( string text)
    {
        _text.text = text;
        
    }
    
    public void FadeIn()
    {
        //_text.alpha = 1f;
        _text.alpha = Mathf.Lerp(0f, 1f, 1f);
    }
    
    public void FadeOut()
    {
        _text.alpha = Mathf.Lerp(1f, 0f, 1f);
    }
}
