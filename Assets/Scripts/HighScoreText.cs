using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
 void Awake()
 {
  GetComponent<TextMeshProUGUI>().text = "Highscore: " + PlayerPrefs.GetInt("highscore1", 0);
 }
}
