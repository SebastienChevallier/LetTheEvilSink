using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldCard : MonoBehaviour, IPointerClickHandler
{
    [Header("Manager")]
    [HideInInspector] public GAMEMANAGER _gameManager;
    [HideInInspector] public CardInfo cardPlayed;

    [Header("Sprite")]
    public Image image;

    [Header("Properties")]
    public Text cardName;
    public Text strength;
    public Text health;
    public Text creatureType;

    [Header("Board")]
    [HideInInspector] public Drop tileInfo;
    public List<GameObject> possibleMovement;


    private void Start()
    {
        _gameManager = FindObjectOfType<GAMEMANAGER>();
        cardPlayed = _gameManager.cardPlayed;

        image.sprite = cardPlayed.image;
        cardName.text = cardPlayed.name;
        strength.text = cardPlayed.strength.ToString();
        health.text = cardPlayed.currentHealth.ToString();
        creatureType.text = cardPlayed.creatureType.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        possibleMovement.Clear();

        foreach (GameObject tile in _gameManager.grid)
        {
            Vector2 moveCoord = tile.GetComponent<Drop>().coord;

            for (int i = 0; i < cardPlayed.moveValue; i++)
            {
                if (cardPlayed.pattern == MovementPattern.Horizontal || cardPlayed.pattern == MovementPattern.Both)
                {
                    if (tileInfo.coord + new Vector2(1 + i, 0) == moveCoord || tileInfo.coord + new Vector2(-1 - i, 0) == moveCoord ||
                        tileInfo.coord + new Vector2(0, 1 + i) == moveCoord || tileInfo.coord + new Vector2(0, -1 - i) == moveCoord)
                    {
                        possibleMovement.Add(tile);
                    }
                }

                if (cardPlayed.pattern == MovementPattern.Diagonal || cardPlayed.pattern == MovementPattern.Both)
                {
                    if (tileInfo.coord + new Vector2(1 + i, 1 + i) == moveCoord || tileInfo.coord + new Vector2(-1 - i, 1 + i) == moveCoord ||
                        tileInfo.coord + new Vector2(1 + i, -1 - i) == moveCoord || tileInfo.coord + new Vector2(-1 - i, -1 - i) == moveCoord)
                    {
                        possibleMovement.Add(tile);
                    }
                }

                else if (cardPlayed.pattern == MovementPattern.L)
                {
                    if (tileInfo.coord + new Vector2(2 + i, 1 + i) == moveCoord || tileInfo.coord + new Vector2(-2 - i, 1 + i) == moveCoord ||
                        tileInfo.coord + new Vector2(2 + i, -1 - i) == moveCoord || tileInfo.coord + new Vector2(-2 - i, -1 - i) == moveCoord ||
                        tileInfo.coord + new Vector2(1 + i, 2 + i) == moveCoord || tileInfo.coord + new Vector2(-1 - i, 2 + i) == moveCoord ||
                        tileInfo.coord + new Vector2(1 + i, -2 - i) == moveCoord || tileInfo.coord + new Vector2(-1 - i, -2 - i) == moveCoord)
                    {
                        possibleMovement.Add(tile);
                    }
                }
            }
        }

        foreach (GameObject move in possibleMovement)
        {
            move.GetComponent<Drop>().image.color = new Color(255, 0, 255, 0.35f);
        }
    }
}
