using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI difficultyText;
    [SerializeField] Transform obstaclesParent;
    [SerializeField] GameObject ball;
    [SerializeField] SpawnManager spawnManager;
    public int score;

    void Awake()
    {
     if (scoreText != null)
     {
      scoreText.text = score.ToString();
     }
    }

    void Update()
    {
     if(scoreText != null)
     {
      scoreText.text = "Score: " + score.ToString();
     }

     if(difficultyText != null)
     {
      difficultyText.text = spawnManager.difficulty;
     }
    }
}
