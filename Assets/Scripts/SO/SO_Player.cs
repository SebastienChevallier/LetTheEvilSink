using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player", order = 0)]
public class SO_Player : ScriptableObject
{
    public string username;
    public Sprite portrait;
    public int mana;
}
