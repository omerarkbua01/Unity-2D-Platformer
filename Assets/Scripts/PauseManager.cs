using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] LevelCompleteManager levelCompleteManager;
    bool isPaused;

    void Start()
    {
        if(pausePanel!=null) pausePanel.SetActive(false);
        Resume();
    }

    // TODO: Hala eski Input System kullaniyor.
    // Ileride New Input System'e tasınacak.
    void Update()
    {
        if(gameOverManager != null && gameOverManager.IsGameOver)
        return;

        if(levelCompleteManager != null && levelCompleteManager.IsLevelComplete)
        return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        isPaused=false;
        Time.timeScale =1f;
        if(pausePanel != null ) pausePanel.SetActive(false);
    }

    public void Pause()
    {
        isPaused=true;
        Time.timeScale=0f;
        if(pausePanel!=null) pausePanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Time.timeScale=1f;
        #if UNITY_EDITOR
        Debug.Log("Quit...");
        #else
        Application.Quit();
        #endif
    }
    
}
