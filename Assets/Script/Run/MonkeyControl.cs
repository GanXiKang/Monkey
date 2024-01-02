using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControl : MonoBehaviour
{
    CharacterController cc;

    int nowRoute;
    bool isTransposition, isA, isD, isJump, isSlide;
    float speed, speedTransposition, verticalSpeed, jumpForce, gravity;
    Vector3 targetPos;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        nowRoute = 2;
        isTransposition = false;
        isA = false;
        isD = false;
        isJump = false;
        isSlide = false;
        speed = 10f;
        speedTransposition = 45f;
        jumpForce = 10f;
        gravity = 30f;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(0, verticalSpeed, -speed);
        cc.Move(moveDirection * Time.deltaTime);

        if (isA)
        {
            RoutePositionX();
            transform.position = Vector3.Lerp(transform.position, targetPos, speedTransposition * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.3f)
            {
                isTransposition = false;
                isA = false;
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
            }
        }
        if (isJump)
        {
            verticalSpeed -= gravity * Time.deltaTime;
            if (cc.isGrounded)
            {
                isTransposition = false;
                isJump = false;
            }
        }
        if (isSlide)
        {
            Invoke("Slide", 0.5f);
        }

        if (!isTransposition)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (nowRoute != 1)
                {
                    print("a");
                    nowRoute--;
                    isTransposition = true;
                    isA = true;

                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (nowRoute != 3)
                {
                    print("d");
                    nowRoute++;
                    isTransposition = true;
                    isD = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                verticalSpeed = jumpForce;
                isTransposition = true;
                isJump = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                print("slide");
                cc.height = 1f;
                isTransposition = true;
                isSlide = true;
            }
        }
    }

    void RoutePositionX()
    {
        switch (nowRoute)
        {
            case 1:
                targetPos = new Vector3(3, transform.position.y, transform.position.z);
                break;

            case 2:
                targetPos = new Vector3(0, transform.position.y, transform.position.z);
                break;

            case 3:
                targetPos = new Vector3(-3, transform.position.y, transform.position.z);
                break;
        }
    }
    void Slide()
    {
        cc.height = 2f;
        isTransposition = false;
        isSlide = false;
    }
}
