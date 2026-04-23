using UnityEngine;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] CheckpointManager checkpointManager;
    [SerializeField] Transform playerTransform;


    
    public int CurrentHealth {get; private set;}
    [SerializeField] TMP_Text healthText;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color hitColor = Color.red;
    [SerializeField] float hitFlashDuration = 0.50f;
    Color originalColor;
    

    void Start()
    {
        if(playerTransform == null)
        playerTransform = transform;

        CurrentHealth = maxHealth;
        UpdateHealthUI();
        if(sr != null)
           originalColor = sr.color;
    }

    public void TakeDamage(int amount)
    {
        if(CurrentHealth <= 0) return;
        CurrentHealth -= amount;
        if(CurrentHealth < 0)
           CurrentHealth = 0;

           UpdateHealthUI();

           if(sr != null)
            {
            StopAllCoroutines();
            StartCoroutine(HitFlash());
            }

           Debug.Log("Player Health : " + CurrentHealth);

           if (CurrentHealth == 0)
            {
            Debug.Log("Player Dead");

            if(checkpointManager != null && checkpointManager.HasCheckpoint())
            {
                RespawnAtCheckpoint();
                return;
            }

            if(gameOverManager != null)
            gameOverManager.ShowGameOver();
            }
    }

    void RespawnAtCheckpoint()
    {
        if(checkpointManager == null || checkpointManager.CurrentCheckpoint == null) return;

        CurrentHealth = maxHealth;
        UpdateHealthUI();

        playerTransform.position = checkpointManager.CurrentCheckpoint.position;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb != null)
        rb.linearVelocity = Vector2.zero;

        if(sr != null)
        sr.color = originalColor;
    }

    void UpdateHealthUI()
    {
        if(healthText != null)
           healthText.text = "Health : " + CurrentHealth;
    }

    System.Collections.IEnumerator HitFlash()
    {
        sr.color = hitColor;
        yield return new WaitForSeconds(hitFlashDuration);
        sr.color = originalColor;
    }

    void Update()
    {
      // DEBUG - KALDIRILACAK  
      //  if (Input.GetKeyDown(KeyCode.H))
      //  {
      //      TakeDamage(1);
      //  }
    }
}
