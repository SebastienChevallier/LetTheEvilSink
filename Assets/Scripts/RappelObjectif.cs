using System.Collections;
using System.Collections.Generic;
using BaseTemplate.Behaviours;
using UnityEngine;
using TMPro;

public class RappelObjectif : MonoSingleton<RappelObjectif>
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textRecuperation;
    public TextMeshProUGUI tutoBriquet;
    
    public void Rappel(string rappel)
    {
        text.text = rappel;
    }

    public void Recup(string texte)
    {
        textRecuperation.text = texte;
    }
}
