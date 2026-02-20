using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
 [SerializeField] GameObject player;
 [SerializeField] Rigidbody2D rb;

 [SerializeField] AudioSource audioSource;
 [SerializeField] AudioClip wooshSound;
 [SerializeField] float volume;

 public Vector2 startPos;
 public Vector2 endPos;
 public Vector2 currentPos;
 public int inverted = 1;
 public bool started = false;

 [SerializeField] float forceMultiplier = 1;

 public void Awake()
 {
  forceMultiplier = PlayerPrefs.GetFloat("sensitivityKey");
  print(forceMultiplier);
  rb.constraints = RigidbodyConstraints2D.FreezePosition;
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
  if(!started){rb.constraints = RigidbodyConstraints2D.None; rb.constraints = RigidbodyConstraints2D.FreezeRotation; started = true;}
  audioSource.PlayOneShot(wooshSound, volume);

  Vector2 dirVector = endPos - startPos;
  Vector2 normalizedDir = dirVector.normalized;
  float distance = Vector2.Distance(startPos, endPos);
  
  if(PlayerPrefs.GetInt("invertedKey") == 1)
  {
   inverted = -1;
   rb.AddForce(normalizedDir * (distance * forceMultiplier) * inverted * .01f, ForceMode2D.Impulse);
  }
  else if(PlayerPrefs.GetInt("invertedKey") == 0)
  {
   inverted = 1;
   rb.AddForce(normalizedDir * (distance * forceMultiplier) * inverted * .01f, ForceMode2D.Impulse);
  }
 }
}