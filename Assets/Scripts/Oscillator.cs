using UnityEngine;

public class Oscillator : MonoBehaviour
{
 [SerializeField] Vector2 movementDirection = Vector2.right;
 [SerializeField] float distance = 2f;
 [SerializeField] float speed = 1f;

 Vector3 startPos;

 void Awake()
 {
  startPos = transform.position;
 }

 void LateUpdate()
 {
  float movementFactor = Mathf.Sin(Time.time * speed);

  Vector3 offset = (Vector3)movementDirection.normalized * (movementFactor * distance);

  transform.position = startPos + offset;
 }
}