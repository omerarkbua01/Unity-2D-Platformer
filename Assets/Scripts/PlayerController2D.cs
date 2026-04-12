using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float speed=8f;
    [SerializeField] float jumpforce=13f;
    [SerializeField] Transform groundCheck;
    [SerializeField ]float groundCheckDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float airControlMultiplier = 0.7f;
    [SerializeField] float fallMultiplier = 3.5f;
    [SerializeField] float lowJumpMultiplier = 3.0f;
    [SerializeField] float coyoteTime = 0.1f;
    [SerializeField] float jumpBufferTime = 0.1f;
    Rigidbody2D rb;
    float moveInput;
    bool jumpHeld;
    float coyoteCounter ;
    float jumpBufferCounter;
    bool isGrounded;
    public bool IsGrounded => isGrounded;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
        if (isGrounded)
        {
            coyoteCounter=coyoteTime;
        }
        else
        {
            coyoteCounter =Mathf.Max(0f, coyoteCounter - Time.deltaTime);
            jumpBufferCounter =Mathf.Max(0f, jumpBufferCounter - Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            jumpBufferCounter = jumpBufferTime;
            jumpHeld = true;
        }
        if (ctx.canceled)
        {
            jumpHeld = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Interact pressed");
        }
    }

    void FixedUpdate()
    {
        float control = isGrounded ? 1f : airControlMultiplier;
        float targetSpeed = moveInput * speed * control;
        rb.linearVelocity = new Vector2(targetSpeed,rb.linearVelocity.y);

        if(jumpBufferCounter > 0f && coyoteCounter > 0f)
        {
            rb.linearVelocity=new Vector2(rb.linearVelocity.x,jumpforce);
            jumpBufferCounter =0f;
            coyoteCounter =0f;
        }
     
        if(rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1f) * Time.fixedDeltaTime
            ;
        }
        else if ( rb.linearVelocity.y >0f && !jumpHeld)
        {
            rb.linearVelocity +=Vector2.up *Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.fixedDeltaTime;
        }

    }
    void CheckGround()
    {
        RaycastHit2D hit= Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDistance,groundLayer);
    isGrounded=hit.collider!=null;
    Debug.DrawRay(groundCheck.position,Vector2.down*groundCheckDistance,isGrounded ? Color.green:Color.red);
    }
}