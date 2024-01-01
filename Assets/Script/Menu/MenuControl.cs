using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject main, ranking, setting;

    public void Button_Start()
    {
        SceneManager.LoadScene(1);
    }
    public void Button_Ranking()
    {
        main.SetActive(false);
        ranking.SetActive(true);
    }
    public void Button_Setting()
    {
        main.SetActive(false);
        setting.SetActive(true);
    }
    public void Button_ExitDoor()
    {
        setting.SetActive(false);
        main.SetActive(true);
    }
    public void Button_Exit()
    {
        Application.Quit();
    }
}
