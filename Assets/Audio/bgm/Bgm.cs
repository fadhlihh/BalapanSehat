using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    private static Bgm instance = null;

    public static Bgm Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            if (instance.GetComponent<AudioSource>().clip != gameObject.GetComponent<AudioSource>().clip)
            {
                instance.GetComponent<AudioSource>().clip = gameObject.GetComponent<AudioSource>().clip;
                instance.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume;
                instance.GetComponent<AudioSource>().Play();
            }

            Destroy(this.gameObject);
            return;
        }
        instance = this;
        gameObject.GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(this.gameObject);
    }
}
