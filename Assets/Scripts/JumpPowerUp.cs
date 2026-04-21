using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float duration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateJumpBoost(duration);
            }

            Destroy(gameObject);
        }
    }
}