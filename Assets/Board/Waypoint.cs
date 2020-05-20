using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject next = null;
    [SerializeField] private GameObject previous = null;
    [SerializeField] private GameObject trap = null;
    [SerializeField] private bool quiz = false;
    [SerializeField] private bool virus = false;
    [SerializeField] private bool cacing = false;
    public GameObject getNext()
    {
        return next;
    }
    public GameObject getPrev()
    {
        return previous;
    }
    public GameObject getTrap()
    {
        return trap;
    }
    public bool isQuiz()
    {
        return quiz;
    }
    public bool isVirus()
    {
        return virus;
    }
    public bool isCacing()
    {
        return cacing;
    }
}
