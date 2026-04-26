using UnityEngine;

public class StompHitbox : MonoBehaviour
{
    [SerializeField] AudioClip stompSfx;
    [SerializeField] float stompVolume = 1f;
    [SerializeField] GameObject stompVfxPrefab;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] float bounceForce = 10f;

    void Reset()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D playerRb = other.attachedRigidbody;
        if (playerRb == null) return;

        if(playerRb.linearVelocity.y >0f) return;

        PlayerController2D playerController = other.GetComponent<PlayerController2D>();
        if(playerController == null) return;

        EnemyDamage enemyDamage = GetComponentInParent<EnemyDamage>();

        if(enemyDamage != null)
        enemyDamage.enabled = false;

        if(enemyHealth != null && enemyHealth.CurrentHealth > 0)
        {
            playerController.Bounce(bounceForce);

            if(stompVfxPrefab != null)
            {
            Debug.Log("Stomp VFX Spawn");
            Instantiate(stompVfxPrefab,enemyHealth.transform.position,Quaternion.identity);
            }

            enemyHealth.TakeDamage(enemyHealth.CurrentHealth);

            if(stompSfx != null)
            AudioSource.PlayClipAtPoint(stompSfx,transform.position,stompVolume);
        } 
    }


}
