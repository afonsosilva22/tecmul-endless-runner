using Unity.VisualScripting;
using UnityEngine;

public class CoinPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioClip coinPowerUpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.ActivateMultiplier(duration);
            AudioSource.PlayClipAtPoint(coinPowerUpSound, transform.position);
            Destroy(gameObject);
        }
    }
}