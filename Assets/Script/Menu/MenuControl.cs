using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    AudioSource BGM;

    public AudioClip button;
    public GameObject main, ranking, setting;

    public static bool isRanking = false;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        if (!isRanking)
        {
            main.SetActive(true);
            ranking.SetActive(false);
        }
        else
        {
            ranking.SetActive(true);
            main.SetActive(false);
            isRanking = false;
        }
        setting.SetActive(false);
    }

    public void Button_Start()
    {
        SceneManager.LoadScene(1);
        BGM.PlayOneShot(button);
    }
    public void Button_Ranking()
    {
        main.SetActive(false);
        ranking.SetActive(true);
        BGM.PlayOneShot(button);
    }
    public void Button_Setting()
    {
        main.SetActive(false);
        setting.SetActive(true);
        BGM.PlayOneShot(button);
    }   
    public void Button_ExitDoor()
    {
        ranking.SetActive(false);
        setting.SetActive(false);
        main.SetActive(true);
        BGM.PlayOneShot(button);
    }
    public void Button_Exit()
    {
        Application.Quit();
        BGM.PlayOneShot(button);
    }   
}
