using UnityEngine;

public class MusicManager : MonoBehaviour
{
 [SerializeField] AudioSource audioSource;
 [SerializeField] AudioClip musicSound;
 [SerializeField] float volume;   

 void Awake()
 {
  audioSource.PlayOneShot(musicSound, volume);
 }
}