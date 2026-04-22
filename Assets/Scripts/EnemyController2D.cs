using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Patrol,
        Chase
    }

    [Header ("Patrol Points")]
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;

    [Header ("Target")]
    [SerializeField] Transform player;

    [Header ("Movement")]
    [SerializeField] float patrolSpeed = 5f;
    [SerializeField] float chaseSpeed = 5f;

    [Header ("Detection")]
    [SerializeField] float detectionRange = 5f;

    [Header ("Idle")]
    [SerializeField] float idleDuration = 0.75f;

    [Header ("Optional")]
    [SerializeField] float stopDistance = 0.1f;

    Rigidbody2D rb;
    SpriteRenderer sr;

    EnemyState currentState;
    Transform targetPoint;
    float idleTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        if(PointA == null || PointB == null || player == null)
        {
            Debug.LogError("EnemyController2D eksik referans var!", this);
            enabled = false;
            return;
        }
        targetPoint = PointB;
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position,player.position);

        if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            if(currentState == EnemyState.Chase)
            {
                currentState = EnemyState.Patrol;
            }
        }
        
        if (currentState == EnemyState.Idle)
        {
            idleTimer -=Time.deltaTime;

            if(idleTimer <= 0f)
            {
                currentState = EnemyState.Patrol;
            }
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
            break;

            case EnemyState.Patrol:
            PatrolMove();
            break;

            case EnemyState.Chase:
            ChaseMove();
            break;
        }
    }

      void PatrolMove()
    {
        Vector2 targetPosition = new Vector2(targetPoint.position.x, rb.position.y);
        MoveTo(targetPosition,patrolSpeed);

        if(Mathf.Abs(rb.position.x - targetPoint.position.x) < 0.05f)
        {
            targetPoint = (targetPoint == PointA) ? PointB : PointA;
            currentState = EnemyState.Idle;
            idleTimer = idleDuration;
        }
    }

    void ChaseMove()
    {
        Vector2 targetPosition = new Vector2(player.position.x, rb.position.y);

        if(Mathf.Abs(rb.position.x - player.position.x) > stopDistance)
        {
            MoveTo(targetPosition, chaseSpeed);
        }
    }

    void MoveTo(Vector2 targetPosition, float speed)
    {
        if(sr != null)
        {
            if(targetPosition.x > rb.position.x)
            sr.flipX = false;
            else if (targetPosition.x < rb.position.x)
            sr.flipX = true;
        }
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition,speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color =Color.yellow;
        Gizmos.DrawWireSphere(transform.position,detectionRange);   
    }
    
       
    

}
