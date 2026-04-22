using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public bool IsGameOver{get; private set;}

    void Start()
    {
        Time.timeScale = 1f;
        if(gameOverPanel != null)
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if(IsGameOver) return;

        IsGameOver = true;
        Time.timeScale = 0f;

        if(gameOverPanel != null)
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
