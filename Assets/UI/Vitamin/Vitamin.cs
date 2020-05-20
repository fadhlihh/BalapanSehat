using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitamin : MonoBehaviour
{
    [SerializeField] private string nama;
    [SerializeField] [TextArea] private string info;
    public string getNama()
    {
        return nama;
    }
    public string getInfo()
    {
        return info;
    }
}
