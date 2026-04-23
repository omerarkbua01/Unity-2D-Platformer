using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 2;
    public int CurrentHealth {get; private set;}

    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -=amount;

        if(CurrentHealth < 0)
           CurrentHealth = 0;

        Debug.Log("EnemyHealth : " + CurrentHealth);

        if(CurrentHealth == 0)
        {
             Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }

    void Update()
    {
    // DEBUG - KALDIRILACAK    
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        TakeDamage(1);
    //    }
    }
}
