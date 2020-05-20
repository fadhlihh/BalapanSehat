using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagerBot : MonoBehaviour
{
    [SerializeField] private GameObject dice;
    public void maju(int step)
    {
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
        {
            if (GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn())
            {
                Debug.Log("QUIZ");
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(false);
            }
            else
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            }
        }
        Debug.Log(GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn());
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            Debug.Log("Here");
            GameObject.Find("Player1").GetComponent<Player1>().movePlayer(step);
        }
        else
        {
            GameObject.Find("Bot").GetComponent<Bot>().movePlayer(step);
        }
    }
    public void mundur2Langkah()
    {
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
        Debug.Log(GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn());
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            Debug.Log("Here");
            GameObject.Find("Player1").GetComponent<Player1>().movePlayer(2);
        }
        else
        {
            GameObject.Find("Bot").GetComponent<Bot>().movePlayer(2);
        }
    }
    public void mundur()
    {
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
        {
            if (GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn())
            {
                Debug.Log("Here");
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(false);
            }
            else
            {
                GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            }
        }
        Debug.Log(GameObject.Find("Dice").GetComponent<Dice>().getPlayer1Turn());
        if (dice.GetComponent<Dice>().getPlayer1Turn())
        {
            Debug.Log("Here");
            GameObject.Find("Player1").GetComponent<Player1>().moveToTrap();
        }
        else
        {
            GameObject.Find("Bot").GetComponent<Bot>().moveToTrap();
        }
    }
}
