using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonAudio;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playButtonAudio()
    {
        audioSource.PlayOneShot(buttonAudio);
    }
}
