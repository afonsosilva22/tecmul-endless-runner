using UnityEngine;

public class CoinPowerUp : MonoBehaviour
{
    public float duration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.ActivateMultiplier(duration);
            Destroy(gameObject);
        }
    }
}