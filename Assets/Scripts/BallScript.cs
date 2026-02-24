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
 [SerializeField] AudioClip highscoreSound;
 [SerializeField] AudioClip lossSound;
 [SerializeField] float volume = 1;
 [SerializeField] GameObject endgameParent;
 [SerializeField] TextMeshProUGUI totalScoreText;
 [SerializeField] GameObject swipeTut;

 public bool gameOver = false;

 public void OnCollisionEnter2D(Collision2D other)
 {
  if(other.gameObject.CompareTag("Obstacle") && !godMode)
  {
   sr.color = Color.red;
   rb.constraints = RigidbodyConstraints2D.FreezeAll;
   EndGame();
  }

  if(other.gameObject.CompareTag("Wall") && !gameOver)
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
   }
  }

  if(Input.GetKeyDown(KeyCode.W))
  {
   spawnManager.SpawnLevel();
  }
 }

 public void EndGame()
 {
  gameOver = true;

  int highscore = PlayerPrefs.GetInt("highscore1", 0);

  saveManager.SaveData();
  endgameParent.SetActive(true);
  
  swipeTut.SetActive(false);
  scoreText.SetActive(false);
  difficultyText.SetActive(false);
  print(highscore);

  if(scoreManager.score > highscore)
  {
   totalScoreText.text = "New Highscore: " + scoreManager.score;
  }
  else
  {
   totalScoreText.text = "Score: " + scoreManager.score;
  }
 }
}