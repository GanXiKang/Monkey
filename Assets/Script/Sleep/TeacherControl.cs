using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherControl : MonoBehaviour
{
    Animator anim;

    public GameObject effect;

    public static bool isAngryEffects;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("T_IdleSitting", true);
        effect.SetActive(false);
        isAngryEffects = false;
    }

    void Update()
    {
        if (isAngryEffects)
        {
            effect.SetActive(true);
        }

        if (SGUIControl.isLose)
        {
            anim.SetBool("T_IdleSitting", false);
            anim.SetBool("T_Angry", true);
        }
    }
}
