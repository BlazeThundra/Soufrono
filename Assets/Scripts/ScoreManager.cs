using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform obstaclesParent;
    [SerializeField] GameObject ball;
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
    }
}
