using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;


public class SpawnManager : MonoBehaviour
{
 int levelGroup = 1;

 [SerializeField] GameObject[] levelPrefabs;

 void Awake()
 {
  int randomPicked = Random.Range(0, levelPrefabs.Length);
  Vector2 spawnPos = new Vector2(0, levelGroup * 14);
  Instantiate(levelPrefabs[randomPicked], spawnPos, Quaternion.identity);
  levelGroup ++;
 }

 public void SpawnLevel()
 {
  int randomPicked = Random.Range(0, levelPrefabs.Length);
  Vector2 spawnPos = new Vector2(0, levelGroup * 14);
  Instantiate(levelPrefabs[randomPicked], spawnPos, Quaternion.identity);
  levelGroup ++;
 }

 public void DeleteLevel()
 {
  foreach(/*child of --obstacles--*/)
  {
   if(group < levelGroup - 1)
   {
    Destroy(gameObject);
   }
  }
 }
}
