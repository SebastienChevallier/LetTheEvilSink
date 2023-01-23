using UnityEngine;

public enum CreatureType { None, Fire, Water, Grass, Electric, Ice, Poison, Steel, Light, Shadow };

public enum MovementPattern { None, Horizontal, Diagonal, Both, L };


[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Creature card", order = 2)]
public class SO_CreatureCard : ScriptableObject
{
    [Header("Properties")]
    public new string name;
    public Sprite image;
    public int cost;
    public int strength;
    public int maxHealth;
    public int currentHealth;
    public string effect;

    public CreatureType type;

    [Header("Movement Pattern")]
    public MovementPattern pattern;
    public int moveValue;


    private void OnEnable()
    {
        currentHealth = maxHealth;

        if (pattern == MovementPattern.L)
        {
            moveValue = 1;
        }
    }

    public void EditStat(int stat, int value)
    {
        stat += value;
    }
}
