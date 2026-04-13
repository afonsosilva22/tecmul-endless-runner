using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}