using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    Animator anim;

    public static bool isFright;

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
        if (isFright)
        {
            anim.SetBool("Frightened", true);
            isFright = false;
        }
        else
        {
            anim.SetBool("Frightened", false);
        }
    }
}
