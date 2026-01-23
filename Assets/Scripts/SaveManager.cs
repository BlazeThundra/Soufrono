using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveManager : MonoBehaviour
{
 [SerializeField] ScoreManager scoreManager;

 public int highscore1 = 0;
 public int highscore2 = 0;
 public int highscore3 = 0;
 public int highscore4 = 0;
 public int highscore5 = 0;
 
 [SerializeField] TextMeshProUGUI highscore1Text;
 [SerializeField] TextMeshProUGUI highscore2Text;
 [SerializeField] TextMeshProUGUI highscore3Text;
 [SerializeField] TextMeshProUGUI highscore4Text;
 [SerializeField] TextMeshProUGUI highscore5Text;
 const string highscore1Key = "highscore1";
 const string highscore2Key = "highscore2";
 const string highscore3Key = "highscore3";
 const string highscore4Key = "highscore4";
 const string highscore5Key = "highscore5";
  
 void Start()
 {
  LoadData();
 }

 void Update()
 {
  if (Keyboard.current.rKey.wasPressedThisFrame)
  {
   ResetScore();
  }

  if (Keyboard.current.sKey.wasPressedThisFrame)
  {
   SaveData();
   LoadData();
  }
 }

 void OnApplicationQuit()
 {
  SaveData();
 }

 void SaveData()
 {
  if(scoreManager.score > PlayerPrefs.GetInt(highscore1Key))
  {
   PlayerPrefs.SetInt(highscore5Key, PlayerPrefs.GetInt(highscore4Key));
   PlayerPrefs.SetInt(highscore4Key, PlayerPrefs.GetInt(highscore3Key));
   PlayerPrefs.SetInt(highscore3Key, PlayerPrefs.GetInt(highscore2Key));
   PlayerPrefs.SetInt(highscore2Key, PlayerPrefs.GetInt(highscore1Key));
   PlayerPrefs.SetInt(highscore1Key, scoreManager.score);
  }
  else if(scoreManager.score > PlayerPrefs.GetInt(highscore2Key))
  {
   PlayerPrefs.SetInt(highscore5Key, PlayerPrefs.GetInt(highscore4Key));
   PlayerPrefs.SetInt(highscore4Key, PlayerPrefs.GetInt(highscore3Key));
   PlayerPrefs.SetInt(highscore3Key, PlayerPrefs.GetInt(highscore2Key));
   PlayerPrefs.SetInt(highscore2Key, scoreManager.score);
  }
  else if(scoreManager.score > PlayerPrefs.GetInt(highscore3Key))
  {
   PlayerPrefs.SetInt(highscore5Key, PlayerPrefs.GetInt(highscore4Key));
   PlayerPrefs.SetInt(highscore4Key, PlayerPrefs.GetInt(highscore3Key));
   PlayerPrefs.SetInt(highscore3Key, scoreManager.score);
  }
  else if(scoreManager.score > PlayerPrefs.GetInt(highscore4Key))
  {
   PlayerPrefs.SetInt(highscore5Key, PlayerPrefs.GetInt(highscore4Key));
   PlayerPrefs.SetInt(highscore4Key, scoreManager.score);
  }
  else if(scoreManager.score > PlayerPrefs.GetInt(highscore5Key))
  {
   PlayerPrefs.SetInt(highscore5Key, scoreManager.score);
  }
  UpdateUI();
 }

 void LoadData()
 {
  highscore1 = PlayerPrefs.GetInt(highscore1Key, 0);
  highscore2 = PlayerPrefs.GetInt(highscore2Key, 0);
  highscore3 = PlayerPrefs.GetInt(highscore3Key, 0);
  highscore4 = PlayerPrefs.GetInt(highscore4Key, 0);
  highscore5 = PlayerPrefs.GetInt(highscore5Key, 0);
  scoreManager.score = 0;
  UpdateUI();
 }

 void ResetScore()
 {
  scoreManager.score = 0;
  PlayerPrefs.SetInt(highscore1Key, 0);
  PlayerPrefs.SetInt(highscore2Key, 0);
  PlayerPrefs.SetInt(highscore3Key, 0);
  PlayerPrefs.SetInt(highscore4Key, 0);
  PlayerPrefs.SetInt(highscore5Key, 0);
  LoadData();
 }

 void UpdateUI()
 {
  if(highscore1Text != null)
  {
   highscore1Text.text = "1)        " + highscore1.ToString();
  }

  if(highscore2Text != null)
  {
   highscore2Text.text = "2)        " + highscore2.ToString();
  }

  if(highscore3Text != null)
  {
   highscore3Text.text = "3)        " + highscore3.ToString();
  }

  if(highscore4Text != null)
  {
   highscore4Text.text = "4)        " + highscore4.ToString();
  }
  
  if(highscore5Text != null)
  {
   highscore5Text.text = "5)        " + highscore5.ToString();
  }
 }
}
