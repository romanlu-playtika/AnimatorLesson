
using System;
using UnityEngine;

public class JimController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 1.0f;
    [SerializeField] LayerMask layerMaskForGrounded;
    [SerializeField] float isGroundedRayLength =0.1f;
    
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigbody2D;

    private int isJumping = Animator.StringToHash("isJumping");
    private int isMoving = Animator.StringToHash("isMoving");
    private int isCrouching = Animator.StringToHash("isCrouching");
    private int isIdle = Animator.StringToHash("isIdle");
    
    private bool isGrounded {
        get {
            Vector3 position = transform.position;
            position.y = GetComponent<Collider2D> ().bounds.min.y + 0.1f;
            float length = isGroundedRayLength + 0.1f;
            Debug.DrawRay (position, Vector3.down * length);
            return Physics2D.Raycast (position, Vector3.down, length, layerMaskForGrounded.value);
        }
    }

    private float currentJumpSpeed;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        EventManager.OnIdleStayEvent += Idle;
    }
    private void OnDisable()
    {
        EventManager.OnIdleStayEvent -= Idle;
    }

    private void Update()
    {
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

    void FixedUpdate()
    {
        Move();
    }

    public void Jump()
    {
        rigbody2D.velocity = new Vector2(rigbody2D.velocity.x, jumpSpeed);
        anim.SetBool(isJumping, true);
    }

    private void Move()
    {
        var input = Input.GetAxis("Horizontal");
        anim.SetBool(isMoving, input != 0.0f);
        spriteRenderer.flipX = (input < 0);
        rigbody2D.velocity = new Vector2(input * walkSpeed, rigbody2D.velocity.y);
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
