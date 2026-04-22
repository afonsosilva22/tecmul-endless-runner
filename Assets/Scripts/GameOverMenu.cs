using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        if (ScoreManager.instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.GetScore();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}