using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseControl : MonoBehaviour
{
    AudioSource BGM;
    public AudioClip button;

    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    public void Button_Again()
    {
        SceneManager.LoadScene(2);
        BGM.PlayOneShot(button);
    }
}
