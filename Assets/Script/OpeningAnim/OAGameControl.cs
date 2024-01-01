using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OAGameControl : MonoBehaviour
{
    void Start()
    {
        Invoke("NextScene", 18f);
    }

    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
