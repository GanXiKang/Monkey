using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepGameControl : MonoBehaviour
{
    public static int score, combo;
    public static float gameTime;

    public GameObject[] keyb = new GameObject[9];
    public GameObject[] comment = new GameObject[6];

    int mode, trueNum, teacherAngry;
    bool isBingo, isEnd;
    float timer;

    void Start()
    {
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
                                SGUIControl.barScore -= 2;
                                teacherAngry++;
                            }
                        }
                    }
                    else
                    {
                        SGUIControl.isLose = true;
                    }
                }
                else
                {
                    SGUIControl.isLose = true;
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
                }
            }
        }
    }

    void RangeMode()
    {
        CloseComments();
        mode = Random.Range(1, 9);
        keyb[mode].SetActive(true);
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
            case 5:
                print("A");
                break;
            case 6:
                print("S");
                break;
            case 7:
                print("D");
                break;
            case 8:
                print("F");
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
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.K))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.L))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 5:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 6:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 7:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    ScoreControl();
                    CloseKeyboard();
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.F))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;

            case 8:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ScoreControl();
                    CloseKeyboard(); 
                }
                if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    comment[4].SetActive(true);
                    CloseKeyboard();
                    SGUIControl.barScore--;
                    teacherAngry++;
                }
                break;
        }
    }
    void ScoreControl()
    {
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

        SGUIControl.barScore++;
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
