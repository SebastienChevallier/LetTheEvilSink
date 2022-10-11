using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objets", menuName = "Objets", order = 1)]
public class So_Objects : ScriptableObject
{
    public int ID;
    public string nom;
    public string description;
    public Sprite image;
    public string texte;
}
