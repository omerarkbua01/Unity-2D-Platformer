using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    [SerializeField] GameObject levelCompletePanel;
    public bool IsLevelComplete{get; private set;}

    void Start()
    {
        Time.timeScale= 1f;
        if(levelCompletePanel != null)
        levelCompletePanel.SetActive(false);
    }

    public void ShowLevelComplete()
    {
        if (IsLevelComplete ) return;
        IsLevelComplete = true;
        Time.timeScale = 0f;

        if(levelCompletePanel != null)
        levelCompletePanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
