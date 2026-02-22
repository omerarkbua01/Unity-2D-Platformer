using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float jumpforce=10f;
    Rigidbody2D rb;
   
    [SerializeField] Transform groundCheck;
    [SerializeField ]float groundCheckDistance = 0.15f;
    [SerializeField] LayerMask groundLayer;
     bool isGrounded;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
      float moveInput= Input.GetAxis("Horizontal");
      rb.linearVelocity=new Vector2(moveInput * speed, rb.linearVelocity.y);
      if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity=new Vector2(rb.linearVelocity.x,jumpforce);
        }
    }
    void CheckGround()
    {
        RaycastHit2D hit= Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDistance,groundLayer);
    isGrounded=hit.collider!=null;
    Debug.DrawRay(groundCheck.position,Vector2.down*groundCheckDistance,isGrounded ? Color.green:Color.red);
    }
}