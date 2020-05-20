using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]private GameObject sfx;
    public void play()
    {
        sfx.GetComponent<AudioSource>().Play();
    }
}
