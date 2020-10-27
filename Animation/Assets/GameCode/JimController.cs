
using UnityEngine;

public class JimController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float idleTimer = 3.0f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private int isJumping = Animator.StringToHash("isJumping");
    private int isMoving = Animator.StringToHash("isMoving");
    private int isCrouching = Animator.StringToHash("isCrouching");
    private int isIdle = Animator.StringToHash("isIdle");
    [SerializeField] float currentIdleTime;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

        Idle();
    }

    public void Jump()
    {
        ResetIdleTimer();
        anim.SetBool(isJumping, !anim.GetBool(isJumping));
    }

    private void Move()
    {
        var input = Input.GetAxis("Horizontal");
        var direction = new Vector2(input, transform.position.y);
        if (input != 0.0f)
        {
            ResetIdleTimer();
        }
        anim.SetBool(isMoving, input != 0.0f);
        spriteRenderer.flipX = (input < 0);
        transform.Translate(direction * walkSpeed * Time.deltaTime);
    }

    private void Crouch(bool crouchBool)
    {
        ResetIdleTimer();
        anim.SetBool(isCrouching, crouchBool);
    }

    private void Idle()
    {
        currentIdleTime += Time.deltaTime;
        if (currentIdleTime > idleTimer)
        {
            anim.SetTrigger(isIdle);
        }
    }

    public void ResetIdleTimer()
    {
        currentIdleTime = 0.0f;
    }
}
