using UnityEngine;

public class CameraMovement : MonoBehaviour
{
 [SerializeField] GameObject cam;
 [SerializeField] GameObject ball;

 void LateUpdate()
 {
  if(cam.transform.position.y <= ball.transform.position.y)
  {
   Vector3 newPos = cam.transform.position;
   newPos.y = ball.transform.position.y;
   newPos.z = -10;
   cam.transform.position = newPos;
  }
 }
}
