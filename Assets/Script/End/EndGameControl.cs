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
        switch (playNum)
        {
            case 1:
                MenuControl.combo[0] = SleepGameControl.combo;
                break;

            case 2:
                MenuControl.combo[1] = SleepGameControl.combo;
                break;

            case 3:
                MenuControl.combo[2] = SleepGameControl.combo;
                break;
        }

        score = (int)Mathf.Round(MonkeyControl.score);
        score += SleepGameControl.score;
        totalScore.text = score.ToString();
        switch (playNum)
        {
            case 1:
                MenuControl.score[0] = score;
                break;

            case 2:
                MenuControl.score[1] = score;
                break;

            case 3:
                MenuControl.score[2] = score;
                break;
        }
    }

    public void InputFieldControl()
    {
        switch (playNum)
        {
            case 1:
                MenuControl.n[0] = inputF.text;
                break;

            case 2:
                MenuControl.n[1] = inputF.text;
                break;

            case 3:
                MenuControl.n[2] = inputF.text;
                break;
        }
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
