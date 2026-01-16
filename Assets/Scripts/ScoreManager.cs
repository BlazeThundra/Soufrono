using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;

    void Awake()
    {
     scoreText.text = score.ToString();
    }

    void Update()
    {
     scoreText.text = score.ToString();
    }
}
