using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public static void SoundPlay(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
}
