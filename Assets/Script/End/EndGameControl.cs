using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{ 
    void Start()
    {
        
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
