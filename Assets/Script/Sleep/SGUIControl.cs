using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SGUIControl : MonoBehaviour
{
    public static int barScore;

    public GameObject main, esc;
    public Image power;
    public Text gameScore;

    float barLength;

    void Start()
    {
        barScore = 3;

        main.SetActive(true);
        esc.SetActive(false);
    }

    void Update()
    {
        gameScore.text = SleepGameControl.score.ToString();

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
    }
    public void Button_Exit()
    {
        SceneManager.LoadScene(0);
    }

    void BarControl()
    {
        if (barScore > 20)
        {
            barScore = 20;
        }
        barLength = (float)barScore / 20;
        barLength *= 5;
        power.rectTransform.localScale = new Vector3(barLength, 1, 1);
    }
}
