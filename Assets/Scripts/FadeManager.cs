using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadeManager : MonoSingleton<FadeManager>
{
    public TextMeshProUGUI _text;
    public Image image;

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

    public void ImageFadeIn()
    {
        Vector4 color = new Vector4(image.color.r, image.color.g, image.color.b, 1);
        image.color = Vector4.Lerp(image.color, color, Time.deltaTime * 1);
    } 
    
    public void ImageFadeOut()
    {
        Vector4 color = new Vector4(image.color.r, image.color.g, image.color.b, 1);
        image.color = Vector4.Lerp(image.color, color, Time.deltaTime * 1);
    }
}
