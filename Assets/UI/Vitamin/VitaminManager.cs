using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitaminManager : MonoBehaviour
{
    [SerializeField] private GameObject nama;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject button;
    public void setPanel(string namaVit,string infoVit)
    {
        nama.GetComponent<Text>().text = namaVit;
        info.GetComponent<Text>().text = infoVit;
        button.SetActive(true);
    }
}
