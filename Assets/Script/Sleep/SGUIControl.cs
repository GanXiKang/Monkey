using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SGUIControl : MonoBehaviour
{
    public GameObject main, esc;

    void Start()
    {
        main.SetActive(true);
        esc.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            main.SetActive(true);
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
}
