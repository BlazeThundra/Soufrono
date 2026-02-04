using UnityEngine;

public class FloorMovement : MonoBehaviour
{
 [SerializeField] Transform ballTransform;
 [SerializeField] Transform cameraTransform;

 [SerializeField] float baseScrollSpeed = 5f; 
 [SerializeField] float distanceWeight = 0.5f; 

 void LateUpdate()
 {
  if (ballTransform == null || cameraTransform == null) return;

  float cameraX = cameraTransform.position.x;
  float distance = Mathf.Max(0, ballTransform.position.y - transform.position.y);
    
  float currentSpeed = baseScrollSpeed + (distance * distanceWeight);

  float newY = transform.position.y + (currentSpeed * Time.deltaTime);
    
  transform.position = new Vector3(cameraX, newY, transform.position.z);
 }
}

//LOOK BACK AT THIS