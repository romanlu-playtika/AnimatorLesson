﻿
using System;
using UnityEngine;

public class JimController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.0f;

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private int isJumping = Animator.StringToHash("isJumping");
    private int isMoving = Animator.StringToHash("isMoving");
    private int isCrouching = Animator.StringToHash("isCrouching");
    private int isIdle = Animator.StringToHash("isIdle");

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        EventManager.OnIdleStayEvent += Idle;
    }
    private void OnDisable()
    {
        EventManager.OnIdleStayEvent -= Idle;
    }

    void Update()
    {
        Move();
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            && !anim.GetBool(isJumping))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C))
        {
            Crouch(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.C))
        {
            Crouch(false);
        }
    }

    public void Jump()
    {
        anim.SetBool(isJumping, !anim.GetBool(isJumping));
    }

    private void Move()
    {
        var input = Input.GetAxis("Horizontal");
        var direction = new Vector2(input, transform.position.y);

        anim.SetBool(isMoving, input != 0.0f);
        spriteRenderer.flipX = (input < 0);
        transform.Translate(direction * walkSpeed * Time.deltaTime);
    }

    private void Crouch(bool crouchBool)
    {
        anim.SetBool(isCrouching, crouchBool);
    }

    private void Idle()
    {
        anim.SetTrigger(isIdle);
    }
}
