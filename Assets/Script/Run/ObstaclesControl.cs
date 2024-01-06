using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControl : MonoBehaviour
{
    GameObject gameControl;
    AudioSource BGM;
    public AudioClip coll;

    void Start()
    {
        gameControl = GameObject.Find("GameControl");
        BGM = gameControl.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MonkeyControl.isGameOver = true;
            BGM.PlayOneShot(coll);
        }
    }
}
