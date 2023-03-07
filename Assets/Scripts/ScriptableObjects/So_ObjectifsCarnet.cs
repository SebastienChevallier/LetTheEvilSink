using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objectifs&Carnet", menuName = "Objectifs&Carnet", order = 4)]
public class So_ObjectifsCarnet : ScriptableObject
{
    public bool _Objectif1;
    public bool _Objectif2;
    
    public bool _Carnet1;
    public bool _Carnet2;
    public bool _Carnet3;
    public bool _Carnet4;
    public bool _Carnet5;
    public bool _Carnet6;

    public void Reset()
    {
        _Objectif1 = false;
        _Objectif2 = false;
        
        _Carnet1 = false;
        _Carnet2 = false;
        _Carnet3 = false;
        _Carnet4 = false;
        _Carnet5 = false;
        _Carnet6 = false;
    }

    public void SetCarnet(string reference)
    {
        switch (reference)
        {
            case "Carnet1":
                _Carnet1 = true;
                break;
            
            case "Carnet2":
                _Carnet2 = true;
                break;
            
            case "Carnet3":
                _Carnet3 = true;
                break;
            
            case "Carnet4":
                _Carnet4 = true;
                break;
            
            case " Carnet5":
                _Carnet5 = true;
                break;
            
            case "Carnet6":
                _Carnet6 = true;
                break;
            
            default:            
                break;
        }
    }
}
