using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioSource jumpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateJumpBoost(duration);
            }
            
            jumpSound.Play();
            Destroy(gameObject);
        }
    }
}