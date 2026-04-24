using System;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioClip shieldSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateShield(duration);
            }
            
            AudioSource.PlayClipAtPoint(shieldSound, transform.position);
            Destroy(gameObject);
        }
    }
}