using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    
    public int CurrentHealth {get; private set;}
    [SerializeField] TMP_Text healthText;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color hitColor = Color.red;
    [SerializeField] float hitFlashDuration = 0.50f;
    Color originalColor;
    

    void Start()
    {
        CurrentHealth = maxHealth;
        UpdateHealthUI();
        if(sr != null)
           originalColor = sr.color;
    }

    public void TakeDamage(int amount)
    {
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
            }
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
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }
    }
}
