using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The purpose of this class is to provide an easy way to play audiosources for objects that may have 
/// multiple different sounds for the same purpose. An example would be having a few different gunshot noises
/// for the same gun.
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    [Header("Audio Files and Sources")]
    [SerializeField] List<AudioClip> clips = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public AudioClip GetRandomClip()
    {
        if (clips.Count <= 0) { return null; }
        return clips[Random.Range(0, clips.Count)];
    }

    public void PlayRandomClip()
    {
        audioSource.clip = GetRandomClip();
        audioSource.Play();
    }
}
