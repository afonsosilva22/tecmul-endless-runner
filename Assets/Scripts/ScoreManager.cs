using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int coins = 0;
    private float distance = 0f;

    private Transform player;
    private float startZ;
    
    public int coinMultiplier = 1;
    public Coroutine multiplierCoroutine;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI distanceText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startZ = player.position.z;
        UpdateScoreUI();
    }

    void Update()
    {
        if (player == null)
        { 
            return;
        }

        distance = player.position.z - startZ;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance) + "m";
        UpdateScoreUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount * coinMultiplier;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(coins + distance * 0.25f);
    }

    void UpdateScoreUI()
    {
        coinText.text = "Coins: " + coins;
    }

    public void ActivateMultiplier(float duration)
    {
        if (multiplierCoroutine != null)
        {
            StopCoroutine(multiplierCoroutine);
        }

        multiplierCoroutine = StartCoroutine(MultiplierTimer(duration));
    }

    IEnumerator MultiplierTimer(float duration)
    {
        coinMultiplier = 5;

        yield return new WaitForSeconds(duration);

        coinMultiplier = 1;
    }
}