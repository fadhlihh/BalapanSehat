using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private GameObject currentWaypoint;
    private GameObject nextWaypoint;
    private GameObject previousWaypoint;
    [SerializeField] float moveDelay = 0.5f;
    [SerializeField] float movementSpeed = 0.001f;
    [SerializeField] private GameObject quiz;
    [SerializeField] private GameObject vitamin;
    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject cacing;
    [SerializeField] private GameObject gameOverPanel;
    private void Start()
    {
        currentWaypoint = GameObject.Find("WaypointP21");
        nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
    }
    public void movePlayer(int step)
    {
        GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        StartCoroutine("move",step);
    }

    public void movePlayerBack(int step)
    {
        GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        StartCoroutine("moveBack", step);
    }

    public IEnumerator move(int step)
    {
        for (int i = 0; i < step; i++)
        {
            if (currentWaypoint == GameObject.Find("WaypointP250"))
            {
                previousWaypoint = GameObject.Find("WaypointP250").GetComponent<Waypoint>().getPrev();
                movePlayerBack(step-i);
                break;
            }
            gameObject.transform.Translate((nextWaypoint.transform.position - gameObject.transform.position), Space.World);
            currentWaypoint = nextWaypoint;
            nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
            previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
            yield return new WaitForSeconds(moveDelay);
        }
        if (currentWaypoint == GameObject.Find("WaypointP250"))
        {
            if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() == null)
            {
                GameObject.Find("Board").GetComponent<PlayRule>().setPlayerNo1(gameObject);
            }
            else
            {
                GameObject.Find("Board").GetComponent<PlayRule>().setPlayerNo2(gameObject);
                gameOverPanel.GetComponent<Pemenang>().setUrutan();
                gameOverPanel.SetActive(true);
            }

        }
        if(currentWaypoint.GetComponent<Waypoint>().isQuiz())
        {
            movePlayer(2);
            //quiz.GetComponent<QuizManager>().randomSoal();
            //quiz.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Vitamin>()!=null)
        {
            movePlayer(3);
            //vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            //vitamin.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            moveToTrap();
            //virus.GetComponent<Virus>().setPanel();
            //virus.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            moveToTrap();
            //cacing.GetComponent<Cacing>().setPanel();
            //cacing.SetActive(true);
        }
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() != GameObject.Find("Player1"))
        {
            GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
        }
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }

    public IEnumerator moveBack(int step)
    {
        for (int i = 0; i < step; i++)
        {
            Debug.Log("hereback");
            gameObject.transform.Translate((previousWaypoint.transform.position - gameObject.transform.position), Space.World);
            currentWaypoint = previousWaypoint;
            previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
            nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
            yield return new WaitForSeconds(moveDelay);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isQuiz())
        {
            Debug.Log("herequiz");
            movePlayer(2);
            //quiz.GetComponent<QuizManager>().randomSoal();
            //quiz.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Vitamin>() != null)
        {
            movePlayer(3);
            //vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            //vitamin.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            moveToTrap();
            //virus.GetComponent<Virus>().setPanel();
            //virus.SetActive(true);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            moveToTrap();
            //cacing.GetComponent<Cacing>().setPanel();
            //cacing.SetActive(true);
        }
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() != GameObject.Find("Player1"))
        {
            GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
        }
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }

    public void moveToTrap()
    {
        gameObject.transform.Translate((currentWaypoint.GetComponent<Waypoint>().getTrap().transform.position - gameObject.transform.position), Space.World);
        currentWaypoint = currentWaypoint.GetComponent<Waypoint>().getTrap();
        previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
        nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
        if (GameObject.Find("Board").GetComponent <PlayRule>().getPlayerno1() != GameObject.Find("Player1"))
        {
            GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
        }
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }
}
