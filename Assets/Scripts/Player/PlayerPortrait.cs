using UnityEngine;
using UnityEngine.UI;

public class PlayerPortrait : MonoBehaviour
{
    public Image portrait;
    public Text username;
    public Text deckAmount;
    public Text graveyardAmount;
    public Text handAmount;
    public PlayerType playerType;
    public SO_Player player;

    void Update()
    {
        portrait.sprite = player.portrait;
        username.text = player.username;
    }
}