using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int value = 1;
    [SerializeField] AudioSource coinSound;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddCoin(value);
            coinSound.Play();
            Destroy(gameObject);
        }
    }
}