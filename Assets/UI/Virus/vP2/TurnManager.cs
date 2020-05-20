using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject dice;
    public void maju(int step)
    {
        GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
        {
            if (GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn())
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(false);
            }
            else
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            }
        }
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            GameObject.Find("Player1").GetComponent<Player>().movePlayer(step);
        }
        else
        {
            GameObject.Find("Player2").GetComponent<Player2>().movePlayer(step);
        }
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }
    public void mundur2Langkah()
    {
        GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
        {
            if (GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn())
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(false);
            }
            else
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            }
        }
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            GameObject.Find("Player1").GetComponent<Player>().movePlayerBack(2);
        }
        else
        {
            GameObject.Find("Player2").GetComponent<Player2>().movePlayerBack(2);
        }
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }
    public void mundur()
    {
        GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
        {
            if (GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn())
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(false);
            }
            else
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            }
        }
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            GameObject.Find("Player1").GetComponent<Player>().moveToTrap();
        }
        else
        {
            GameObject.Find("Player2").GetComponent<Player2>().moveToTrap();
        }
    }

}
