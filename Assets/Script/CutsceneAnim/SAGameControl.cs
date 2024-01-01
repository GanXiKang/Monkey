using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SAGameControl : MonoBehaviour
{
    void Start()
    {
        Invoke("NextScene", 15f);
    }

    void NextScene()
    {
        SceneManager.LoadScene(4);
    }
}
