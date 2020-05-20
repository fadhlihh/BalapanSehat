using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player0 : MonoBehaviour
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
    [SerializeField] private GameObject walk;
    [SerializeField] private GameObject advantage;
    [SerializeField] private GameObject trap;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject gameover;

    private void Start()
    {
        currentWaypoint = GameObject.Find("WaypointP11");
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
            walk.GetComponent<AudioSource>().Play();
            if (currentWaypoint == GameObject.Find("WaypointP150"))
            {
                previousWaypoint = GameObject.Find("WaypointP150").GetComponent<Waypoint>().getPrev();
                movePlayerBack(step-i);
                break;
            }
            gameObject.transform.Translate((nextWaypoint.transform.position - gameObject.transform.position), Space.World);
            currentWaypoint = nextWaypoint;
            nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
            previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
            yield return new WaitForSeconds(moveDelay);
        }
        if (currentWaypoint == GameObject.Find("WaypointP150"))
        {
            gameover.GetComponent<AudioSource>().Play();
            gameOverPanel.SetActive(true);
        }else
        if(currentWaypoint.GetComponent<Waypoint>().isQuiz())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            quiz.GetComponent<QuizManager>().randomSoal();
            quiz.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Vitamin>()!=null)
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            advantage.GetComponent<AudioSource>().Play();
            vitamin.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            virus.GetComponent<Virus>().setPanel();
            trap.GetComponent<AudioSource>().Play();
            virus.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            cacing.GetComponent<Cacing>().setPanel();
            trap.GetComponent<AudioSource>().Play();
            cacing.SetActive(true);
        }
        else
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = true;
        }
    }

    public IEnumerator moveBack(int step)
    {
        for (int i = 0; i < step; i++)
        {
            walk.GetComponent<AudioSource>().Play();
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
            vitamin.GetComponent<VitaminManager>().setPanel(currentWaypoint.GetComponent<Vitamin>().getNama(), currentWaypoint.GetComponent<Vitamin>().getInfo());
            advantage.GetComponent<AudioSource>().Play();
            vitamin.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isVirus())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            virus.GetComponent<Virus>().setPanel();
            trap.GetComponent<AudioSource>().Play();
            virus.SetActive(true);
        }else
        if (currentWaypoint.GetComponent<Waypoint>().isCacing())
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = false;
            popup.GetComponent<AudioSource>().Play();
            cacing.GetComponent<Cacing>().setPanel();
            trap.GetComponent<AudioSource>().Play();
            cacing.SetActive(true);
        }
        else
        {
            GameObject.Find("Dice").GetComponent<Button>().enabled = true;
        }
    }

    public void moveToTrap()
    {
        gameObject.transform.Translate((currentWaypoint.GetComponent<Waypoint>().getTrap().transform.position - gameObject.transform.position), Space.World);
        currentWaypoint = currentWaypoint.GetComponent<Waypoint>().getTrap();
        previousWaypoint = currentWaypoint.GetComponent<Waypoint>().getPrev();
        nextWaypoint = currentWaypoint.GetComponent<Waypoint>().getNext();
        GameObject.Find("Dice").GetComponent<Button>().enabled = true;
    }
}
