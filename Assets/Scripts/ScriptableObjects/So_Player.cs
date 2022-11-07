using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data", order = 2)]
public class So_Player : ScriptableObject
{
    [Header("Angoisse")]
    public int _MaxAngoisse;
    public int _ValAngoisse;

    [Header("Vitesse")]
    public float _WalkSpeed;
    public float _RunSpeed;

    [Header("Vie")]
    public int _MaxVie;
    public int _ValVie;

    [Header("Bool")]
    public bool _CanInteract;
    public bool _CanTalk;
    public bool _CanLight;
    public bool _CanMove = true;
    public bool _Hiding = false;
    public bool _InDark = false;

    

    [Header("World Interactions")]
    public GameObject _TriggerObject;

}
