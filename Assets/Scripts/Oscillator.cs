using System;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
 [SerializeField] float distance = 2f;
 Vector2 startPos;

 void Awake()
 {
  startPos = new Vector2(transform.position.x, transform.position.y);
 }

 void LateUpdate()
 {
  float movementFactor = Mathf.Sin(Time.time * distance);

  Vector3 offset = transform.right * (movementFactor * distance);

  transform.position = (Vector3)startPos + offset;
 }
}
