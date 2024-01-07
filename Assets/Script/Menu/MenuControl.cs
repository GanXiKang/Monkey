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
    public GameObject[] top = new GameObject[3];
    public Text[] playerName = new Text[3];
    public Text[] playerScore = new Text[3];
    public Text[] playerCombo = new Text[3];

    public static bool isRanking = false;
    public static string[] n = new string[3];
    public static int[] score, combo = new int[3];

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

        switch (EndGameControl.playNum)
        {
            case 1:
                playerName[0].text = n[0].ToString();
                playerScore[0].text = score[0].ToString() + " s";
                playerCombo[0].text = combo[0].ToString() + " combo";
                break;

            case 2:
                playerName[0].text = n[0].ToString();
                playerScore[0].text = score[0].ToString() + " s";
                playerCombo[0].text = combo[0].ToString() + " combo";
                playerName[1].text = n[1].ToString();
                playerScore[1].text = score[1].ToString() + " s";
                playerCombo[1].text = combo[1].ToString() + " combo";
                break;

            case 3:
                playerName[0].text = n[0].ToString();
                playerScore[0].text = score[0].ToString() + " s";
                playerCombo[0].text = combo[0].ToString() + " combo";
                playerName[1].text = n[1].ToString();
                playerScore[1].text = score[1].ToString() + " s";
                playerCombo[1].text = combo[1].ToString() + " combo";
                playerName[2].text = n[2].ToString();
                playerScore[2].text = score[2].ToString() + " s";
                playerCombo[2].text = combo[3].ToString() + " combo";
                break;
        }
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
