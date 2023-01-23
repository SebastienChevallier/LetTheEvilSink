using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decks", menuName = "Scriptable Objects/Decks", order = 4)]
public class SO_Decks : ScriptableObject
{
    public Dictionary<List<GameObject>, string> deckTab = new Dictionary<List<GameObject>, string>();



    public void AddDeck(List<GameObject> deck, string deckName)
    {
        deckTab.Add(deck, deckName);
    }

    public void RemoveDeck(List<GameObject> deck)
    {
        deckTab.Remove(deck);
    }

    public void EditDeck(List<GameObject> deck, string deckName)
    {
        deckTab.Remove(deck);
        deckTab.Add(deck, deckName);
    }
}
