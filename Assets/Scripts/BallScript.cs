using UnityEngine;

public class BallScript : MonoBehaviour
{
 [SerializeField] SpawnManager spawnManager;

 public void OnCollisionEnter2D(Collision2D other)
 {
  if(other.gameObject.CompareTag("Obstacle"))
  {
   //EndGame();
  }
 }

 public void OnTriggerEnter2D(Collider2D other)
 {
  if(other.gameObject.CompareTag("SpawnZone"))
  {
   spawnManager.SpawnLevel();
  }
 }
}