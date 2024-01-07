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
    public static string n;
    public static int score, combo;

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
                playerName[0].text = n.ToString();
                playerScore[0].text = score.ToString();
                playerCombo[0].text = combo.ToString();
                break;

            case 2:
                playerName[1].text = n.ToString();
                playerScore[1].text = score.ToString();
                playerCombo[1].text = combo.ToString();
                break;

            case 3:
                playerName[2].text = n.ToString();
                playerScore[2].text = score.ToString();
                playerCombo[2].text = combo.ToString();
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
