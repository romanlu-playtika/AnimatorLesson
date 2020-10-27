
using UnityEngine;

public class JimController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)) && !anim.GetBool("isJumping"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        anim.SetBool("isJumping", !anim.GetBool("isJumping"));
    }

    private void Move()
    {
        var input = Input.GetAxis("Horizontal");
        var direction = new Vector2(input, transform.position.y);
        anim.SetBool("isMoving", input != 0.0f);
        spriteRenderer.flipX = (input < 0);
        transform.Translate(direction * walkSpeed * Time.deltaTime);
    }
}
