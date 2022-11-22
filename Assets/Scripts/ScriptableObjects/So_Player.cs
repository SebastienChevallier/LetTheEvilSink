using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data", order = 2)]
public class So_Player : ScriptableObject
{
    [Header("Angoisse")]
    public float _MaxAngoisse;
    public float _ValAngoisse;

    [Header("Vitesse")]
    public float _WalkSpeed;
    public float _RunSpeed;
    public float _DashDist;

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
    public bool _Invincible = false;

    

    [Header("World Interactions")]
    public GameObject _TriggerObject;

}
