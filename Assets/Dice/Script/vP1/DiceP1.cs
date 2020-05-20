using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DiceP1 : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float diceSpeed = 0.1f;
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
        GameObject.Find("Player1").GetComponent<Player0>().movePlayer(sides + 1);
    }
}
