using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject main, ranking, setting;
    public Toggle fullScreen;

    //public static bool isFullS_record;

    void Start()
    {
        main.SetActive(true);
        ranking.SetActive(false);
        setting.SetActive(false);

        fullScreen.isOn = Screen.fullScreen;
    }

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
    public void Button_FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        //isFullS_record = isFullScreen;
    }
}
