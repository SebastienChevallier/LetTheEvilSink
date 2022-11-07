using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Discution", menuName = "Dial", order = 3)]
public class So_Discution : ScriptableObject
{
    public _Discutions[] _Dialog;
    public Sprite _Perso1;
    public Sprite _Perso2;

    [System.Serializable]
    public struct _Discutions
    {
        public bool _PlayerIsSpeaking;
        public Sprite _SpritePerso;
        public string _NomPerso;
        public string _Discution;
    }

    
}
