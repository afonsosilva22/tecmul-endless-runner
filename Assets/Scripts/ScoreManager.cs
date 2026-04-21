using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    
    public int coinMultiplier = 1;
    public Coroutine multiplierCoroutine;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
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