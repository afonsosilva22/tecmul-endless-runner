using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioSource speedSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.ActivateSpeedBoost(duration);
            }

            speedSound.Play();
            Destroy(gameObject);
        }
    }
}