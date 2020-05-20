using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pemenang : MonoBehaviour
{
    [SerializeField] private GameObject urutan;
    public void setUrutan()
    {
        urutan.GetComponent<Text>().text += "\n1. " + GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno1().name+"\n2. "+ GameObject.Find("Board").GetComponent<PlayRule>().getPlayerno2().name;
    }
}
