using UnityEditor.Search;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
 public bool scored = false;
 public int group;
 GameObject ball;
 GameObject managers;
 
 void Awake()
 {
  gameObject.transform.parent = GameObject.Find("--Obstacles--").transform;
  ball = GameObject.Find("Ball");
  managers = GameObject.Find("Managers");
 }

 void Update()
 {
  if(!scored && CompareTag("Obstacle"))
  {
   if(ball.transform.position.y > transform.position.y)
   {
        scored = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        managers.GetComponent<ScoreManager>().score ++;
   }
  }
 }
}