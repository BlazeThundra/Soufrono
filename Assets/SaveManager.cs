using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveManager : MonoBehaviour
{
 public int highscore;
 [SerializeField] TextMeshProUGUI highscoreText;
 const string highscoreKey = "highscore";

 void Start()
 {
  LoadData();
 }

 void Update()
 {
  if (Keyboard.current.rKey.isPressed)
  {
   ResetScore();
  }
 }

 void OnApplicationQuit()
 {
  SaveData();
 }

 void SaveData()
 {
  PlayerPrefs.SetInt(highscoreKey, 0);
  //  PlayerPrefs.SetInt(highscoreKey, GetComponent<ScoreManager>().score);
 }

 void LoadData()
 {
  highscore = PlayerPrefs.GetInt(highscoreKey, 0);
  UpdateUI();
 }

 void ResetScore()
 {
  GetComponent<ScoreManager>().score = 0;
  PlayerPrefs.SetInt(highscoreKey, GetComponent<ScoreManager>().score);
  UpdateUI();
 }

 void UpdateUI()
 {
  highscoreText.text = highscore.ToString();
 }
}
