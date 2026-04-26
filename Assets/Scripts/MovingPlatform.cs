
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 4f;

    Rigidbody2D rb;
    Transform targetPoint;
    Vector2 platformVelocity;
    PlayerController2D rider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(pointA == null || pointB == null)
        {
            Debug.LogError("MovingPlatform point eksik", this);
            enabled = false;
            return;
        }
        targetPoint = pointB;
    }

    void FixedUpdate()
    {
        Vector2 oldPosition = rb.position;
        Vector2 newPosition = Vector2.MoveTowards(oldPosition, targetPoint.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        platformVelocity = (newPosition - oldPosition) / Time.fixedDeltaTime;

        if(Vector2.Distance(newPosition, targetPoint.position) < 0.05f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) return;

        if(collision.transform.position.y > transform.position.y)
        {
            rider = collision.gameObject.GetComponent<PlayerController2D>();

            if(rider != null)
            {
                rider.ExternalVelocity = platformVelocity;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) return;

        if(rider != null && collision.gameObject == rider.gameObject)
        {
            rider.ExternalVelocity = Vector2.zero;
            rider = null;
        }
    }
}
