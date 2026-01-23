using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
 [SerializeField] SpawnManager spawnManager;
 [SerializeField] SpriteRenderer sr;
 [SerializeField] Rigidbody2D rb;

 public void OnCollisionEnter2D(Collision2D other)
 {
  if(other.gameObject.CompareTag("Obstacle"))
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
  }
 }

 public IEnumerator EndGame()
 {
  yield return new WaitForSeconds(2f);
  SceneManager.LoadScene("MainMenu");
 }
}