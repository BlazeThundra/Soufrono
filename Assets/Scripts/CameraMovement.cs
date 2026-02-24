using Unity.Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
 [SerializeField] GameObject ball;
 [SerializeField] GameObject cinemachine;

 public float smoothTime = 1f; 
 private float zoomVelocity = 0f; 

 void LateUpdate()
 {
  float targetSize = 10f + (ball.GetComponent<Rigidbody2D>().linearVelocityY * 0.1f); 
  var lens = cinemachine.GetComponent<CinemachineCamera>().Lens;

  lens.OrthographicSize = Mathf.SmoothDamp(
  lens.OrthographicSize, 
  targetSize, 
  ref zoomVelocity, 
  smoothTime
  );

  cinemachine.GetComponent<CinemachineCamera>().Lens = lens;
 }
}