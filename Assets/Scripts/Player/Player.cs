using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerType
{
    PLAYER,
    ENEMY
};

public class Player : MonoBehaviour
{
    public SO_Player player;


    private void Start()
    {
        player.mana++;
    }
}
