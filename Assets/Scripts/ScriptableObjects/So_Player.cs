using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data", order = 2)]
public class So_Player : ScriptableObject
{
    [Header("Angoisse")]
    public int _MaxAngoisse;
    public int _ValAngoisse;

    [Header("Vie")]
    public int _MaxVie;
    public int _ValVie;

    [Header("Inventaire")]
    public So_Objects[] _Inventaire;
}
