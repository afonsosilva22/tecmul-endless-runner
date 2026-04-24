using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioClip jumpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateJumpBoost(duration);
            }
            
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            Destroy(gameObject);
        }
    }
}