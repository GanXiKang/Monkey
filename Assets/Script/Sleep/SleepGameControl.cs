using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepGameControl : MonoBehaviour
{
    AudioSource BGM;

    public static int score, combo;
    public static float gameTime;

    public GameObject[] keyb = new GameObject[9];
    public GameObject[] comment = new GameObject[6];
    public AudioClip correct, miss, angry, awake;

    int mode, trueNum, teacherAngry;
    bool isBingo, isEnd;
    float timer;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        Invoke("RangeMode", 2f);
        score = 0;
        trueNum = 0;
        combo = trueNum;
        gameTime = 60f;
        teacherAngry = 0;
        isEnd = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        gameTime -= Time.deltaTime;

        if (!SGUIControl.isLose)
        {
            if (gameTime > 0)
            {
                if (SGUIControl.barScore > 0)
                {
                    if (teacherAngry < 5)
                    {
                        if (isBingo)
                        {
                            if (timer <= 2f)
                            {
                                keyboard();
                            }
                            else
                            {
                                comment[5].SetActive(true);
                                CloseKeyboard();
                                trueNum = 0;
                                SGUIControl.barScore -= 2;
                                teacherAngry++;
                                BGM.PlayOneShot(awake);
                            }
                        }
                    }
                    else
                    {
                        SGUIControl.isLose = true;
                        BGM.PlayOneShot(angry);
                    }
                }
                else
                {
                    SGUIControl.isLose = true;
                    BGM.PlayOneShot(angry);
                }
            }
            else
            {
                if (SGUIControl.barScore >= 7)
                {
                    if (!isEnd)
                    {
                        StartCoroutine(NextScene());
                    }
                }
                else
                {
                    SGUIControl.isLose = true;
                    BGM.PlayOneShot(angry);
                }
            }
        }

        if (trueNum > combo)
        {
            combo = trueNum;
            print("combo");
        }
    }

    void RangeMode()
    {
        CloseComments();
        mode = Random.Range(1, 9);
        keyb[mode].SetActive(true);
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
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 5:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 6:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 7:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.F))
                {
                    MissControl();
                }
                break;

            case 8:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ScoreControl();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    MissControl();
                }
                break;
        }
    }
    void ScoreControl()
    {
        CloseKeyboard();

        if (timer <= 0.5f)
        {
            comment[3].SetActive(true);
            score += 5;
        }
        else if (timer <= 1.2f)
        {
            comment[2].SetActive(true);
            score += 3;
        }
        else if (timer <= 2f)
        {
            comment[1].SetActive(true);
            score += 1;
        }

        trueNum++;
        SGUIControl.barScore++;
        BGM.PlayOneShot(correct);
    }
    void MissControl()
    {
        CloseKeyboard();
        comment[4].SetActive(true);
        trueNum = 0;
        SGUIControl.barScore--;
        teacherAngry++;
        BGM.PlayOneShot(miss);
    }
    void CloseKeyboard()
    {
        isBingo = false;
        Invoke("RangeMode", 1f);
        for (int i = 1; i < keyb.Length; i++)
        {
            keyb[i].SetActive(false); 
        }
    }
    void CloseComments() 
    {
        for (int k = 1; k < comment.Length; k++)
        {
            comment[k].SetActive(false);
        }
    }

    IEnumerator NextScene()
    {
        isEnd = true;
        if (SGUIControl.barScore >= 20)
        {
            score += 50;
        }
        else if(SGUIControl.barScore >= 14)
        {
            score += 30;
        }
        else if (SGUIControl.barScore >= 7)
        {
            score += 10;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}
