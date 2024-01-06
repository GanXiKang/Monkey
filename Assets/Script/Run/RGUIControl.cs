using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RGUIControl : MonoBehaviour
{
    AudioSource BGM;

    public AudioClip button;
    public GameObject main, esc;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        main.SetActive(true);
        esc.SetActive(false);
    }

    void Update()
    {
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
}
