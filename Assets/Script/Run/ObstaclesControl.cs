using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControl : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip coll;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MonkeyControl.isGameOver = true;
            BGM.PlayOneShot(coll);
        }
    }
}
