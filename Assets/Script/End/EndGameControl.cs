using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    public Text combo, score;

    void Start()
    {
        combo.text = SleepGameControl.combo.ToString();
    }
    void Update()
    {
        
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
