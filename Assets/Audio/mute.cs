using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mute : MonoBehaviour
{
    [SerializeField] private GameObject toggle;
    public void ToggleSound()
    {
        if (toggle.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
    private void Update()
    {
        ToggleSound();
    }
}
