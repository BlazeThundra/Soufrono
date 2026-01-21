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
     scoreText.text = score.ToString();
    }

    void Update()
    {
     scoreText.text = score.ToString();

     foreach(Transform obstacle in obstaclesParent)
     {
      if(ball.transform.position.y > obstacle.transform.position.y && obstacle.GetComponent<Obstacle>().scored == false)
      {
       obstacle.GetComponent<Obstacle>().scored = true;
       obstacle.GetComponent<SpriteRenderer>().color = Color.red;
       score ++;
      }
     }
    }
}
