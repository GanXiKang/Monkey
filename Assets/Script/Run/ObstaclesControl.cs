using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        print("hi");
        if (other.gameObject.name == "MonkeyStudent")
        {
            print("ok");
        }
    }
}
