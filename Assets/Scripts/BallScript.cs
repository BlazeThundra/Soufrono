using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
 [SerializeField] SpawnManager spawnManager;
 [SerializeField] SaveManager saveManager;
 [SerializeField] SpriteRenderer sr;
 [SerializeField] Rigidbody2D rb;
 bool godMode = false;

 public void OnCollisionEnter2D(Collision2D other)
 {
  if(other.gameObject.CompareTag("Obstacle") && !godMode)
  {
   sr.color = Color.red;
   rb.constraints = RigidbodyConstraints2D.FreezeAll;
   StartCoroutine(EndGame());
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

 public IEnumerator EndGame()
 {
   saveManager.SaveData();
   yield return new WaitForSeconds(2f);
   SceneManager.LoadScene("MainMenu");
 }
}