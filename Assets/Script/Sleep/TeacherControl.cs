using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherControl : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("T_IdleSitting", true);
    }

    void Update()
    {
        if (SGUIControl.isLose)
        {
            anim.SetBool("T_IdleSitting", false);
            anim.SetBool("T_Angry", true);
        }
    }
}
