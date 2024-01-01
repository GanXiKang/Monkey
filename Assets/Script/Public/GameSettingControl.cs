using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingControl : MonoBehaviour
{
    AudioSource BGM;

    public Toggle fullScreen;
    public Slider volume;

    public static bool isFullS_record;
    public static float volumeNum;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        fullScreen.isOn = Screen.fullScreen;
        volumeNum = 0.7f;
        volume.value = volumeNum;
    }

    public void Button_Volume()
    {
        volumeNum = volume.value;
        BGM.volume = volumeNum;
    }
    public void Button_FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFullS_record = isFullScreen;
    }
}
