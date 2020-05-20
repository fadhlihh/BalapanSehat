using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRule : MonoBehaviour
{
    [SerializeField] private GameObject playerNo1;
    [SerializeField] private GameObject playerNo2;
    private void Start()
    {
        playerNo1 = null;
        playerNo2 = null;
    }
    public void setPlayerNo1(GameObject playerNo1)
    {
        this.playerNo1 = playerNo1;
    }
    public void setPlayerNo2(GameObject playerNo2)
    {
        this.playerNo2 = playerNo2;
    }
    public GameObject getPlayerno1()
    {
        return playerNo1;
    }
    public GameObject getPlayerno2()
    {
        return playerNo2;
    }
}
