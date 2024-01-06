using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("Idle_Sitting", true);
    }

    void Update()
    {
        
    }
}
