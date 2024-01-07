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
    public RectTransform[] top = new RectTransform[3];
    public Text[] playerName = new Text[3];
    public Text[] playerScore = new Text[3];
    public Text[] playerCombo = new Text[3];

    public static bool isRanking = false;
    public static string[] n = new string[3];
    public static int[] score = new int[3];
    public static int[] combo = new int[3];

    RectTransform t;

    void Start()
    {
        test();
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
                RankingTop();
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
                RankingTop();
                break;
        }
    }

    void RankingTop()
    {
        if (score[0] < score[1])
        {
            t.position = top[0].position;
            top[0].position = top[1].position;
            top[1].position = t.position;
        }
        if (EndGameControl.playNum == 3)
        {
            if (score[0] < score[2])
            {
                t.position = top[0].transform.position;
                top[0].transform.position = top[2].transform.position;
                top[2].transform.position = t.position;
            }
            if (score[1] < score[2])
            {
                t.position = top[1].transform.position;
                top[1].transform.position = top[2].transform.position;
                top[2].transform.position = t.position;
            }
        }
    }
    void test()
    {
        EndGameControl.playNum = 2;
        n[0] = "11111";
        n[1] = "22222";
        score[0] = 100;
        score[1] = 120;
        combo[0] = 10;
        combo[1] = 30;
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
