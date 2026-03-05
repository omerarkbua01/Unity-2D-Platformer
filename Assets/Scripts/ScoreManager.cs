using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    public int Score {get; private set;}
    [SerializeField] TMP_Text scoreText;

    void Awake()
    {
        if(Instance !=null && Instance !=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        Score +=amount;
        Debug.Log($"Score :  {Score}");
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if(scoreText!=null)
           scoreText.text=$"Score : {Score}";
    }
}
