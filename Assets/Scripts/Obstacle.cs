using UnityEditor.Search;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
 public bool scored = false;
 public int group;
 
 void Awake()
 {
//   GameObject obstacleParent = ;
  transform.parent = null;
 }
}
