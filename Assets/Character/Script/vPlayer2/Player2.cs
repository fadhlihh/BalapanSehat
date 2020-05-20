using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player2 : MonoBehaviour
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
    [SerializeField] private GameObject player1Mask;
    [SerializeField] private GameObject player2Mask;
    [SerializeField] private GameObject image1Mask;
    [SerializeField] private GameObject image2Mask;
    [SerializeField] private GameObject text1Mask;
    [SerializeField] private GameObject text2Mask;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject advantage;
    [SerializeField] private GameObject gameOver;
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
            gameObject.GetComponent<AudioSource>().Play();
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
                GameObject.Find("Dice").GetComponent<Button>().enabled = true;
            }
            else
            {
                GameObject.Find("Board").GetComponent<PlayRule>().setPlayerNo2(gameObject);
                gameOverPanel.GetComponent<Pemenang>().setUrutan();
                gameOver.GetComponent<AudioSource>().Play();
                gameOverPanel.SetActive(true);
            }

        }else
        if(currentWaypoint.GetComponent<Waypoint>().isQuiz())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            quiz.GetComponent<QuizManager>().randomSoal();
            quiz.SetActive(true);
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
        }else
        if (currentWaypoint.GetComponent<Vitamin>()!=null)
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            advantage.GetComponent<AudioSource>().Play();
            vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            vitamin.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            trap.GetComponent<AudioSource>().Play();
            virus.GetComponent<Virus>().setPanel();
            virus.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            trap.GetComponent<AudioSource>().Play();
            cacing.GetComponent<Cacing>().setPanel();
            cacing.SetActive(true);
        }
        else
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() != GameObject.Find("Player1"))
        {
            GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            player1Mask.SetActive(true);
            player2Mask.SetActive(false);
            image1Mask.SetActive(true);
            image2Mask.SetActive(false);
            text1Mask.GetComponent<Text>().color = new Color(0.361f, 0.592f, 0.8f);
            text2Mask.GetComponent<Text>().color = new Color(0, 0, 0);
        }
    }

    public IEnumerator moveBack(int step)
    {
        for (int i = 0; i < step; i++)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("hereback");
            gameObject.transform.Translate((previousWaypoint.transform.position - gameObject.transform.position), Space.World);
            currentWaypoint = previousWaypoint;
            previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
            nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
            yield return new WaitForSeconds(moveDelay);
        }
        if (currentWaypoint.GetComponent<Waypoint>().isQuiz())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            quiz.GetComponent<QuizManager>().randomSoal();
            quiz.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Vitamin>() != null)
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            advantage.GetComponent<AudioSource>().Play();
            vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            vitamin.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            trap.GetComponent<AudioSource>().Play();
            virus.GetComponent<Virus>().setPanel();
            virus.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            trap.GetComponent<AudioSource>().Play();
            cacing.GetComponent<Cacing>().setPanel();
            cacing.SetActive(true);
        }
        else
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1() != GameObject.Find("Player1"))
        {
            GameObject.Find("Dice").GetComponent<Dice>().setPlayer1Turn(true);
            player1Mask.SetActive(true);
            player2Mask.SetActive(false);
            image1Mask.SetActive(true);
            image2Mask.SetActive(false);
            text1Mask.GetComponent<Text>().color = new Color(0.361f, 0.592f, 0.8f);
            text2Mask.GetComponent<Text>().color = new Color(0, 0, 0);
        }
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
