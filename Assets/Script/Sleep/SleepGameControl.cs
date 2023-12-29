using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepGameControl : MonoBehaviour
{
    int mode;
    bool isBingo, isStart;
    float timer;

    void Start()
    {
        Invoke("RangeMode", 2f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isBingo)
        {
            if (timer <= 3f)
            {
                keyboard();
            }
            else
            {
                isBingo = false;
                print("timeout");
                Invoke("RangeMode", 1f);
            }
        }
    }

    void RangeMode()
    {
        mode = Random.Range(1, 5);
        switch (mode)
        {
            case 1:
                print("H");
                break;
            case 2:
                print("J");
                break;
            case 3:
                print("K");
                break;
            case 4:
                print("L");
                break;
        }
        isBingo = true;
        timer = 0;
    }
    void keyboard()
    {
        switch (mode)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.H))
                {
                    score();
                    isBingo = false;
                    Invoke("RangeMode", 1f);
                }
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
                {
                    print("Miss");
                    isBingo = false;
                    Invoke("RangeMode", 1f);
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    score();
                    isBingo = false;
                    Invoke("RangeMode", 1f);
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
                {
                    score();
                    print("Miss");
                    isBingo = false;
                    Invoke("RangeMode", 1f);
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    score();
                    isBingo = false;
                    Invoke("RangeMode", 1f);
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
                {
                    print("Miss");
                    isBingo = false;
                    RangeMode();
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    score();
                    isBingo = false;
                    RangeMode();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
                {
                    print("Miss");
                    isBingo = false;
                    RangeMode();
                }
                break;
        }
    }
    void score()
    {
        if (timer <= 1f)
        {
            print("Excellent");
        }
        else if (timer <= 2f)
        {
            print("Great!");
        }
        else if (timer <= 3f)
        {
            print("Nice!");
        }
    }
}
