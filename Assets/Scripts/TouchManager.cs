using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
 [SerializeField] GameObject player;
 [SerializeField] Rigidbody2D rb;

 public Vector2 startPos;
 public Vector2 endPos;
 public Vector2 currentPos;
 public int inverted = 1;

 [SerializeField] float forceMultiplier;

 public void Awake()
 {
    
 }

 public void Start()
 {
  rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
 }

 public void OnTouchPosition(InputAction.CallbackContext ctx)
 {
  currentPos = ctx.ReadValue<Vector2>();
 }

 public void OnTouchPress(InputAction.CallbackContext ctx)
 {
  if (ctx.started)
  {
   startPos = currentPos;
  }

  else if (ctx.canceled)
  {
   endPos = currentPos;
   ApplyForce();
  }
 }

 public void ApplyForce()
 {
  Vector2 dirVector = endPos - startPos;
  Vector2 normalizedDir = dirVector.normalized;
  float distance = Vector2.Distance(startPos, endPos);
  
  if(PlayerPrefs.GetInt("invertedKey") == 1)
  {
   inverted = -1;
   rb.AddForce(normalizedDir * (distance * forceMultiplier) * inverted, ForceMode2D.Impulse);
  }
  else if(PlayerPrefs.GetInt("invertedKey") == 0)
  {
   inverted = 1;
   rb.AddForce(normalizedDir * (distance * forceMultiplier) * inverted, ForceMode2D.Impulse);
  }
 }
}