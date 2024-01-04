using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SGUIControl : MonoBehaviour
{
    AudioSource BGM;

    public static int barScore;

    public AudioClip button;
    public GameObject main, esc;
    public Image power, knob;

    float barLength;

    void Start()
    {
        barScore = 3;

        main.SetActive(true);
        esc.SetActive(false);
    }

    void Update()
    {
        BarControl();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(true);
            main.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Button_Continue()
    {
        main.SetActive(true);
        esc.SetActive(false);
        Time.timeScale = 1f;
        BGM.PlayOneShot(button);
    }
    public void Button_Exit()
    {
        SceneManager.LoadScene(0);
        BGM.PlayOneShot(button);
    }

    void BarControl()
    {
        if (barScore < 7)
        {
            power.color = Color.red;
        }
        if (barScore >= 7 && barScore < 20)
        {
            power.color = Color.green;
        }
        if (barScore >= 20)
        {
            barScore = 20;
            power.color = Color.blue;
        }

        barLength = (float)barScore / 20;
        barLength *= 5;
        power.rectTransform.localScale = new Vector3(barLength, 1, 1);
    }
}
