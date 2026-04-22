using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] float damageCooldown = 1f;

    float cooldownTimer;

    void Update()
    {
        if(cooldownTimer > 0f)
           cooldownTimer -=Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (cooldownTimer > 0f) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if(playerHealth !=null)
            {
                playerHealth.TakeDamage(damageAmount);
                cooldownTimer = damageCooldown;
            }
        }
    }
}
