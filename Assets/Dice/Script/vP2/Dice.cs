using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float diceSpeed = 0.1f;
    [SerializeField] private bool isPlayer1Turn = true;
    public void rollDice()
    {
        gameObject.GetComponent<Button>().enabled = false;
        StartCoroutine("randomDiceSide");
    }

    private IEnumerator randomDiceSide()
    {
        int sides = 0;
        for (int i = 0; i < 25; i++)
        {
            sides = Random.Range(0, 6);
            gameObject.GetComponent<Image>().overrideSprite = sprites[sides];
            yield return new WaitForSeconds(diceSpeed);
        }
        if (isPlayer1Turn)
        {
            GameObject.Find("Player1").GetComponent<Player>().movePlayer(sides + 1);
        }
        else
        {
            GameObject.Find("Player2").GetComponent<Player2>().movePlayer(sides + 1);
        }
    }

    public bool getPlayer1Turn()
    {
        return isPlayer1Turn;
    }
    public void setPlayer1Turn(bool turn)
    {
        isPlayer1Turn = turn;
    }
}
