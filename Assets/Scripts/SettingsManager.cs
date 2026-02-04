using UnityEngine;

public class SettingsManager : MonoBehaviour
{
 public int invertedControls = 0;
 const string invertedKey = "invertedKey";

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

 public bool LoadBool(string key)
 {
  PlayerPrefs.GetInt(invertedKey, 0);
  return PlayerPrefs.GetInt(key, 0) == 1;
 }
}
