using System;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    [Header("Grid")]
    public Transform gridContent;
    public List<GameObject> grid;

    [HideInInspector] public CardInfo cardPlayed;



    private void Start()
    {
        int x = 1;
        int y = 1;

        foreach (Transform tile in gridContent)
        {
            if (x > 7)
            {
                y++;
                x = 1;
            }

            tile.GetComponent<Drop>().coord = new Vector2(x, y);
            tile.GetComponent<Drop>().tileName = Convert.ToChar('A' + x - 1).ToString() + y.ToString();
            grid.Add(tile.gameObject);

            x++;
        }
    }
}
