using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioClip speedSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateSpeedBoost(duration);
            }

            AudioSource.PlayClipAtPoint(speedSound, transform.position);
            Destroy(gameObject);
        }
    }
}