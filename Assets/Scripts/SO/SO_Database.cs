using System.Collections.Generic;
using System.Linq;
using UnityEngine;



[CreateAssetMenu(fileName = "Database", menuName = "Scriptable Objects/Database", order = 1)]
public class SO_Database : ScriptableObject
{
    public List<ScriptableObject> database;


    private void OnEnable()
    {
        database.Clear();

        var creatureDatabase = Resources.LoadAll("CreatureCards", typeof(SO_CreatureCard)).Cast<SO_CreatureCard>().OrderBy(card => card.cost);
        var spellDatabase = Resources.LoadAll("SpellCards", typeof(SO_SpellCard)).Cast<SO_SpellCard>().OrderBy(card => card.cost).OrderBy(card => card.type);

        foreach (SO_CreatureCard cc in creatureDatabase)
        {
            database.Add(cc);
        }

        foreach (SO_SpellCard sc in spellDatabase)
        {
            database.Add(sc);
        }
    }
}

