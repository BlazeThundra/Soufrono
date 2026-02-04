using UnityEngine;

public class SettingsManager : MonoBehaviour
{
 public int invertedControls = 0;
 const string invertedKey = "0";

 public void InvertedToggle(string key)
 {
    int invertedControls = PlayerPrefs.GetInt(invertedKey, 0);
    int newValue = invertedControls == 1 ? 0 : 1;
    PlayerPrefs.SetInt(invertedKey, newValue);
    print(invertedControls);
 }

 public bool LoadBool(string key)
 {
  return PlayerPrefs.GetInt(key, 0) == 1;
 }
}
