using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Discution", menuName = "Dial", order = 3)]
public class So_Discution : ScriptableObject
{
    public _Discutions[] _Dialog;
    public TMP_FontAsset defaultFont;
    
    [System.Serializable]
    public struct _Discutions
    {
        public bool _PlayerIsSpeaking;
        public Sprite _SpritePerso;
        public TMP_FontAsset font;
        public string _NomPerso;
        public string _Discution;
    }

    
}
