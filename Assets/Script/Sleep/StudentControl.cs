using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    Animator anim;

    public static bool isFright;

    public GameObject effect;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("Idle_Sitting", true);
        anim.SetBool("GoSleep", true);
        anim.SetBool("Sleeping", true);

        isFright = false;
    }

    void Update()
    {
        if (SGUIControl.isLose)
        {
            isFright = true;
        }

        if (isFright)
        {
            anim.SetBool("Frightened", true);
            isFright = false;
            effect.SetActive(false);
        }
        else
        {
            anim.SetBool("Frightened", false);
            effect.SetActive(true);
        }
    }
}