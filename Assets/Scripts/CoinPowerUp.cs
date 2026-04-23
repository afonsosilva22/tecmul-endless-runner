using Unity.VisualScripting;
using UnityEngine;

public class CoinPowerUp : MonoBehaviour
{
    public float duration = 10f;
    [SerializeField] AudioSource coinPowerUpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.ActivateMultiplier(duration);
            coinPowerUpSound.Play();
            Destroy(gameObject);
        }
    }
}