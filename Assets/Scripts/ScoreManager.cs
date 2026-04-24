using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

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
    public TextMeshProUGUI powerUpText;

    public float speedTimer;
    public float jumpTimer;
    public float shieldTimer;
    public float coinTimer;

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
        distanceText.text = "" + Mathf.FloorToInt(distance) + "m";
        UpdateTimers();
        UpdatePowerUpUI();
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
        coinText.text = "" + coins;
    }

    void UpdateTimers()
    {
        if (speedTimer > 0) speedTimer -= Time.deltaTime;
        if (jumpTimer > 0) jumpTimer -= Time.deltaTime;
        if (shieldTimer > 0) shieldTimer -= Time.deltaTime;
        if (coinTimer > 0) coinTimer -= Time.deltaTime;
    }

    void UpdatePowerUpUI()
    {
        string text = "";

        if (speedTimer > 0)
            text += "2x Speed - " + FormatTime(speedTimer) + "\n";

        if (jumpTimer > 0)
            text += "Mega Jump - " + FormatTime(jumpTimer) + "\n";

        if (shieldTimer > 0)
            text += "Shield - " + FormatTime(shieldTimer) + "\n";

        if (coinTimer > 0)
            text += "5x Coins - " + FormatTime(coinTimer) + "\n";

        powerUpText.text = text;
    }

    string FormatTime(float time)
    {
        int seconds = Mathf.CeilToInt(time);
        return seconds + "s";
    }

    public void ActivateMultiplier(float duration)
    {
        coinTimer = duration;

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