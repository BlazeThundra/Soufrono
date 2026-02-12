
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
 public int levelGroup = 1;
 float levelHorizontalOffset = 0;

 [SerializeField] GameObject[] levelPrefabs;
 [SerializeField] GameObject obstacleParent;

 void Awake()
 {
  SpawnLevel();
 }

 public void SpawnLevel()
 {
  int randomPicked = Random.Range(0, levelPrefabs.Length);
  GameObject selectedPrefab = levelPrefabs[randomPicked];

  Vector2 spawnPos = new Vector2(levelHorizontalOffset, levelGroup * 14);
  Instantiate(levelPrefabs[randomPicked], spawnPos, Quaternion.identity);
  if(selectedPrefab.name.Contains("SlopeRight2Boxes"))
  {
   levelHorizontalOffset += 7f;
  }
  if(selectedPrefab.name.Contains("SlopeLeft2Boxes"))
  {
   levelHorizontalOffset += -7f;
  }
  levelGroup ++;
  DeleteLevel();
 }

 public void DeleteLevel()
 {
  foreach(Transform child in obstacleParent.transform)
  {
   if(child.GetComponent<Obstacle>().group < levelGroup - 3)
   {
    Destroy(child.gameObject);
   }
  }
 }
}