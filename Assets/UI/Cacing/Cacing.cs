using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cacing : MonoBehaviour
{
    [SerializeField] [TextArea] private string[] info;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject button;
    public void setPanel()
    {
        button.SetActive(true);
        int chInfo = Random.Range(0, 3);
        infoPanel.GetComponent<Text>().text = info[chInfo];
    }
}
