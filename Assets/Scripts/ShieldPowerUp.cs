using System;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioSource shieldSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateShield(duration);
            }
            
            shieldSound.Play();
            Destroy(gameObject);
        }
    }
}