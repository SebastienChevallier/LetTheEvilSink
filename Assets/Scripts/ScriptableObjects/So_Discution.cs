using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Discution", menuName = "Dial", order = 3)]
public class So_Discution : ScriptableObject
{
    public _Discutions[] _Dialog;
    public TMP_FontAsset defaultFont;
    public Sprite narratorSprite;
    
    [System.Serializable]
    public struct _Discutions
    {
        //public bool _PlayerIsSpeaking;
        public bool narratorIsSpeaking;
        public Sprite _SpritePerso;
        public TMP_FontAsset font;
        public string _NomPerso;
        
        [TextArea]
        public string _Discution;
    }

    
}
