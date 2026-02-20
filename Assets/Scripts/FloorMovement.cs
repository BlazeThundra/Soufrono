using UnityEngine;

public class FloorMovement : MonoBehaviour
{
 [SerializeField] Transform ballTransform;
 [SerializeField] Transform camTransform;

 [SerializeField] TouchManager touchManager;

 [SerializeField] float baseSpeed = 5f; 
 [SerializeField] float distanceWeight = 0.5f; 

 void LateUpdate()
 {
  if (ballTransform == null || camTransform == null || !touchManager.started) return;

  float camX = camTransform.position.x;
  float distance = Mathf.Max(0, ballTransform.position.y - transform.position.y);
    
  float currentSpeed = baseSpeed + (distance * distanceWeight);

  float newY = transform.position.y + (currentSpeed * Time.deltaTime);
    
  transform.position = new Vector3(camX, newY, transform.position.z);
 }
}