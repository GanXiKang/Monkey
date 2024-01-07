using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    public static int playNum = 0;

    public InputField inputF;
    public Text combo, totalScore;

    int score;

    void Start()
    {
        playNum++;

        combo.text = SleepGameControl.combo.ToString();
        MenuControl.combo = SleepGameControl.combo;

        score = (int)Mathf.Round(MonkeyControl.score);
        score += SleepGameControl.score;
        totalScore.text = score.ToString();
        MenuControl.score = score;
    }

    public void InputFieldControl()
    {
        MenuControl.n = inputF.text;
    }
    public void Button_OK()
    {
        SceneManager.LoadScene(0);
    }
    public void Button_Ranking()
    {
        MenuControl.isRanking = true;
        SceneManager.LoadScene(0);
    }
}
