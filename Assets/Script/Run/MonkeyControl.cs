using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyControl : MonoBehaviour
{
    Animator anim;
    CharacterController cc;
    CapsuleCollider capC;

    int nowRoute;
    bool isTransposition, isA, isD, isJump, isSlide;
    float speed, speedTransposition, verticalSpeed, jumpForce, gravity;
    Vector3 targetPos;

    public AudioSource BGM;
    public AudioClip jump, slide;
    public GameObject effect;

    public static bool isGameOver;
    public static float score;

    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        capC = GetComponent<CapsuleCollider>();

        anim.SetBool("Run", true);

        isTransposition = false;
        isA = false;
        isD = false;
        isJump = false;
        isSlide = false;
        isGameOver = false;

        nowRoute = 2;
        speed = 10f;
        speedTransposition = 45f;
        jumpForce = 15f;
        gravity = 35f;
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;

            Vector3 moveDirection = new Vector3(0, verticalSpeed, speed);
            cc.Move(moveDirection * Time.deltaTime);

            if (isA)
            {
                RoutePositionX();
                transform.position = Vector3.Lerp(transform.position, targetPos, speedTransposition * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPos) < 0.3f)
                {
                    isTransposition = false;
                    isA = false;
                    anim.SetBool("RunLeft", false);
                }
            }
            if (isD)
            {
                RoutePositionX();
                transform.position = Vector3.Lerp(transform.position, targetPos, speedTransposition * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPos) < 0.3f)
                {
                    isTransposition = false;
                    isD = false;
                    anim.SetBool("RunRight", false);
                }
            }
            if (isJump)
            {
                verticalSpeed -= gravity * Time.deltaTime;
                if (cc.isGrounded)
                {
                    isTransposition = false;
                    isJump = false;
                    anim.SetBool("Jump", false);
                }
            }
            if (isSlide)
            {
                Invoke("Slide", 0.8f);
            }

            if (!isTransposition)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (nowRoute != 1)
                    {
                        nowRoute--;
                        isTransposition = true;
                        isA = true;
                        anim.SetBool("RunLeft", true);
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (nowRoute != 3)
                    {
                        nowRoute++;
                        isTransposition = true;
                        isD = true;
                        anim.SetBool("RunRight", true);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalSpeed = jumpForce;
                    isTransposition = true;
                    isJump = true;
                    anim.SetBool("Jump", true);
                    BGM.PlayOneShot(jump);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    cc.height = 2f;
                    cc.center = Vector3.zero;
                    capC.height = 2f;
                    capC.center = Vector3.zero;
                    isTransposition = true;
                    isSlide = true;
                    anim.SetBool("Slide", true);
                    BGM.PlayOneShot(slide);
                }
            }
        }
        else 
        {
            anim.SetBool("Slip", true);
            effect.SetActive(false);
            Invoke("GameEnd", 1.5f);
        }
    }

    void RoutePositionX()
    {
        switch (nowRoute)
        {
            case 1:
                targetPos = new Vector3(-3, transform.position.y, transform.position.z);
                break;

            case 2:
                targetPos = new Vector3(0, transform.position.y, transform.position.z);
                break;

            case 3:
                targetPos = new Vector3(3, transform.position.y, transform.position.z);
                break;
        }
    }
    void Slide()
    {
        cc.height = 4f;
        cc.center = new Vector3(0, 0.5f, 0);
        capC.height = 4f;
        capC.center = new Vector3(0, 0.5f, 0);
        isTransposition = false;
        isSlide = false;
        anim.SetBool("Slide", false);
    }
    void GameEnd()
    {
        SceneManager.LoadScene(5);
    }
}
