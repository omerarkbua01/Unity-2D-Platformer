using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float jumpforce=10f;
    [SerializeField] Transform groundCheck;
    [SerializeField ]float groundCheckDistance = 0.15f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float airControlMultiplier = 0.5f;
    Rigidbody2D rb;
    float moveInput;
    bool jumpPressed;
    bool isGrounded;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
        moveInput= Input.GetAxis("Horizontal");
      if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed=true;
        }
    }

    void FixedUpdate()
    {
        float control = isGrounded ? 1f : airControlMultiplier;
        float targetSpeed = moveInput * speed * control;
        rb.linearVelocity = new Vector2(targetSpeed,rb.linearVelocity.y);

        if(jumpPressed && isGrounded)
        {
            rb.linearVelocity=new Vector2(rb.linearVelocity.x,jumpforce);
        }
        jumpPressed=false;
        
    }
    void CheckGround()
    {
        RaycastHit2D hit= Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDistance,groundLayer);
    isGrounded=hit.collider!=null;
    Debug.DrawRay(groundCheck.position,Vector2.down*groundCheckDistance,isGrounded ? Color.green:Color.red);
    }
}