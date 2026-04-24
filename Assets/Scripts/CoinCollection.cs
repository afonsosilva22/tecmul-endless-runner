using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int value = 1;
    [SerializeField] AudioClip coinSound;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddCoin(value);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}