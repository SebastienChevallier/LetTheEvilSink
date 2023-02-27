using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carnet : MonoBehaviour
{
    public So_ObjectifsCarnet _ObjectifsCarnet;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject note6;

    private void OnEnable()
    {
        //set true or false the notes
        if(_ObjectifsCarnet._Carnet1)
            note1.SetActive(true);
        if(_ObjectifsCarnet._Carnet2)
            note2.SetActive(true);
        if(_ObjectifsCarnet._Carnet3)
            note3.SetActive(true);
        if (_ObjectifsCarnet._Carnet4)
            note4.SetActive(true);
        if(_ObjectifsCarnet._Carnet5)
            note5.SetActive(true);
        if(_ObjectifsCarnet._Carnet6)
            note6.SetActive(true);
    }
}
