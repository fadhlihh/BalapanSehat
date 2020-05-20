using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] Quiz[] quiz;
    [SerializeField] private GameObject soal;
    [SerializeField] private GameObject btnJawab;
    [SerializeField] private GameObject status;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject btnMaju;
    [SerializeField] private GameObject btnMundur;
    [SerializeField] private GameObject advantage;
    [SerializeField] private GameObject trap;
    private int currentSoal=0;
    public void randomSoal()
    {
        currentSoal = Random.Range(0, 8);
        soal.GetComponent<Text>().text = quiz[currentSoal].soal;
    }
    public void cekBenar()
    {
        if (quiz[currentSoal].jawaban == true)
        {
            btnJawab.SetActive(false);
            status.GetComponent<Text>().text = "BENAR";
            status.SetActive(true);
            info.GetComponent<Text>().text = quiz[currentSoal].info;
            info.SetActive(true);
            btnMaju.SetActive(true);
            advantage.GetComponent<AudioSource>().Play();
        }
        else
        {
            btnJawab.SetActive(false);
            status.GetComponent<Text>().text = "SALAH";
            status.SetActive(true);
            info.GetComponent<Text>().text = quiz[currentSoal].info;
            info.SetActive(true);
            btnMundur.SetActive(true);
            trap.GetComponent<AudioSource>().Play();
        }
    }
    public void cekSalah()
    {
        if (quiz[currentSoal].jawaban == false)
        {
            btnJawab.SetActive(false);
            status.GetComponent<Text>().text = "BENAR";
            status.SetActive(true);
            info.GetComponent<Text>().text = quiz[currentSoal].info;
            info.SetActive(true);
            btnMaju.SetActive(true);
            advantage.GetComponent<AudioSource>().Play();
        }
        else
        {
            btnJawab.SetActive(false);
            status.GetComponent<Text>().text = "SALAH";
            status.SetActive(true);
            info.GetComponent<Text>().text = quiz[currentSoal].info;
            info.SetActive(true);
            btnMundur.SetActive(true);
            trap.GetComponent<AudioSource>().Play();
        }
    }
}
