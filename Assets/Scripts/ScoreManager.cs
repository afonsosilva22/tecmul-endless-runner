using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;

    private Transform player;
    private float startZ;
    
    public int coinMultiplier = 1;
    public Coroutine multiplierCoroutine;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startZ = player.position.z;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distance = player.position.z - startZ;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance) + "m";
    }

    public void AddScore(int amount)
    {
        score += amount * coinMultiplier;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Coins: " + score;
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