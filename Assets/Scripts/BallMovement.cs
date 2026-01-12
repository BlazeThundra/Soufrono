using UnityEngine;

public class BallMovement : MonoBehaviour
{
 Rigidbody2D rb;

 void Awake()
 {
  rb = GetComponent<Rigidbody2D>();
 }
 
 void Start()
 {
        
 }

 void Update()
 {
  if(GetKeyDown(KeyCode.Mouse0)
  {
   rb.linearvelocity += new Vector3(0,5,0);
  }  
 }
}
