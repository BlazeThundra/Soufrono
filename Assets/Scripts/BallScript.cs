using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
 [SerializeField] SpawnManager spawnManager;
 [SerializeField] SaveManager saveManager;
 [SerializeField] ScoreManager scoreManager;
 [SerializeField] SpriteRenderer sr;
 [SerializeField] Rigidbody2D rb;
 bool godMode = false;
 [SerializeField] GameObject scoreText;
 [SerializeField] GameObject difficultyText;
 [SerializeField] AudioSource audioSource;
 [SerializeField] AudioClip bonkSound;
 [SerializeField] float volume = 1;
 [SerializeField] GameObject endgameParent;
 [SerializeField] TextMeshProUGUI totalScoreText;

 public void OnCollisionEnter2D(Collision2D other)
 {
  if(other.gameObject.CompareTag("Obstacle") && !godMode)
  {
   sr.color = Color.red;
   rb.constraints = RigidbodyConstraints2D.FreezeAll;
   EndGame();
  }

  if(other.gameObject.CompareTag("Wall"))
  {
   audioSource.PlayOneShot(bonkSound, volume);
  }
 }

 public void OnTriggerEnter2D(Collider2D other)
 {
  if(other.gameObject.CompareTag("SpawnZone"))
  {
   spawnManager.SpawnLevel();
   Destroy(other.gameObject);
  }
 }

 void Update()
 {
  if(Input.GetKeyDown(KeyCode.Space))
  {
   if(!godMode)
   {
    godMode = true;
    print("godMode on");
   }
  }

  if(Input.GetKeyDown(KeyCode.W))
  {
   spawnManager.SpawnLevel();
  }
 }

 public void EndGame()
 {
  int highscore = PlayerPrefs.GetInt("highscore1", 0);

  saveManager.SaveData();
  endgameParent.SetActive(true);
  
  scoreText.SetActive(false);
  difficultyText.SetActive(false);
  print(highscore);

  if(scoreManager.score > highscore)
  {
   totalScoreText.text = "New Highscore: " + scoreManager.score;
   print("new highscore");
  }
  else
  {
   totalScoreText.text = "Score: " + scoreManager.score;
  }
 }
}