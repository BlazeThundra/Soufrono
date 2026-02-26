using UnityEngine;

public class SpawnManager : MonoBehaviour
{
 public int levelGroup = 1;
 float levelHorizontalOffset = 0;

 [SerializeField] GameObject[] easyLevels;
 [SerializeField] GameObject[] mediumLevels;
 [SerializeField] GameObject[] hardLevels;
 [SerializeField] GameObject obstacleParent;
 [SerializeField] ScoreManager scoreManager;

 public string difficulty;

 void Awake()
 {
  SpawnLevel();
 }

 public void SpawnLevel()
 {
  if(scoreManager.score < 20) //Easy levels
  {  
   difficulty = "Easy";
   int randomPicked = Random.Range(0, easyLevels.Length);
   GameObject selectedPrefab = easyLevels[randomPicked];

   Vector2 spawnPos = new Vector2(levelHorizontalOffset, levelGroup * 14);
   Instantiate(easyLevels[randomPicked], spawnPos, Quaternion.identity);
   if(selectedPrefab.name.Contains("SlopeRight"))
   {
    levelHorizontalOffset += 7f;
   }
   if(selectedPrefab.name.Contains("SlopeLeft"))
   {
    levelHorizontalOffset += -7f;
   }
  }

  else if(scoreManager.score < 50) //Medium levels
  {
   difficulty = "Medium";
   int randomPicked = Random.Range(0, mediumLevels.Length);
   GameObject selectedPrefab = mediumLevels[randomPicked];

   Vector2 spawnPos = new Vector2(levelHorizontalOffset, levelGroup * 14);
   Instantiate(mediumLevels[randomPicked], spawnPos, Quaternion.identity);
   if(selectedPrefab.name.Contains("SlopeRight"))
   {
    levelHorizontalOffset += 7f;
   }
   if(selectedPrefab.name.Contains("SlopeLeft"))
   {
    levelHorizontalOffset += -7f;
   }
  }

  else if(scoreManager.score < 50) //Hard levels
  {
   difficulty = "Hard";
   int randomPicked = Random.Range(0, hardLevels.Length);
   GameObject selectedPrefab = hardLevels[randomPicked];

   Vector2 spawnPos = new Vector2(levelHorizontalOffset, levelGroup * 14);
   Instantiate(hardLevels[randomPicked], spawnPos, Quaternion.identity);
   if(selectedPrefab.name.Contains("SlopeRight"))
   {
    print("slopedleft)");
    levelHorizontalOffset += 7f;
   }
   if(selectedPrefab.name.Contains("SlopeLeft"))
   {
    levelHorizontalOffset += -7f;
   }
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