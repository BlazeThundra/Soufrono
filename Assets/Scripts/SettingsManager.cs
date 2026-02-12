using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
 public int invertedControls = 0;
 const string invertedKey = "invertedKey";
 public float sensitivityMult = 1;
 const string sensitivityKey = "sensitivityKey";
 [SerializeField] GameObject sensSlider;
 [SerializeField] TextMeshProUGUI sensText;

 public void InvertedToggle(string key)
 {
    invertedControls = PlayerPrefs.GetInt(invertedKey, 0);
    if(invertedControls == 0)
    {
     invertedControls = 1;
    }
    else{invertedControls = 0;}
    PlayerPrefs.SetInt(invertedKey, invertedControls);
 }

 public void SensitivitySwitch()
 {
  sensitivityMult = sensSlider.GetComponent<Slider>().value;
  sensText.text = "Sensitivity: " + Mathf.CeilToInt(sensitivityMult);
  PlayerPrefs.SetFloat(sensitivityKey, sensitivityMult);
 }

 public bool LoadBool(string key)
 {
  PlayerPrefs.GetInt(invertedKey, 0);
  PlayerPrefs.GetFloat(sensitivityKey, 1);
  return PlayerPrefs.GetInt(key, 0) == 1;
 }
}
