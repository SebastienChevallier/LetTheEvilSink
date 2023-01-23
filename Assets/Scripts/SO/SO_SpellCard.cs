using UnityEngine;

public enum SpellType { None, Action, Support };


[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Spell card", order = 3)]
public class SO_SpellCard : ScriptableObject
{
    public new string name;
    public Sprite image;
    public int cost;
    public string effect;
    public SpellType type;
}
