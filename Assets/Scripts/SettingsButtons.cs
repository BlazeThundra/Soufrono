using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
 [SerializeField] string boolToGrab;
 int toggled;
 Image image;

 void Awake()
 {
  image = GetComponent<Image>();
  ColorUpdate();
 }

 public void ColorUpdate()
 {
  toggled = PlayerPrefs.GetInt(boolToGrab, 0);
  if(toggled == 1)
  {
   image.color = Color.green;
  }
  else{image.color = Color.white;}
 }
}