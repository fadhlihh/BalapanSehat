using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("InGame");
    }
    public void play2P()
    {
        SceneManager.LoadScene("InGame2P");
    }
    public void menuUtama()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
