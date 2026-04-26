using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSfx;
    [SerializeField] float pickupVolume = 1f;
    [SerializeField] GameObject coinVfxPrefab; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Picked!");
            ScoreManager.Instance?.AddScore(1);

            if(coinVfxPrefab != null)
            {
            Instantiate(coinVfxPrefab, transform.position,Quaternion.identity);
            }
            
            if(pickupSfx != null)
            {
                AudioSource.PlayClipAtPoint(pickupSfx,transform.position,pickupVolume);
            }

            Destroy(gameObject);
        }
    }
}
