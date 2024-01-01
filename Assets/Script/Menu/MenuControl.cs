using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    AudioSource BGM;

    public GameObject main, ranking, setting;
    public Toggle fullScreen;
    public Slider volume;

    public static bool isFullS_record;
    public static float volumeNum;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        main.SetActive(true);
        ranking.SetActive(false);
        setting.SetActive(false);

        fullScreen.isOn = Screen.fullScreen;
        volumeNum = 0.7f;
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
    public void Button_Volume()
    {
        volumeNum = volume.value;
        BGM.volume = volumeNum;
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
        isFullS_record = isFullScreen;
    }
}
