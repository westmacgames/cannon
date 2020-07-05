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
    [Header("Audio Files and Sources")]
    AudioSource src = null;
    [SerializeField] List<AudioClip> clips = null;

    [Header("Settings")]
    [Space]

    [SerializeField]
    [Range(0, 1f)] float volume = 1f;

    private void Start()
    {
        src = GetComponent<AudioSource>();
        src.volume = volume;
    }

    AudioClip GetRandomClip()
    {
        if (clips.Count <= 0) { return null; }
        return clips[Random.Range(0, clips.Count)];
    }

    public void PlayRandomClip()
    {
        Debug.Log("Sound omitted by:" + gameObject);
        src.clip = GetRandomClip();
        src.Play();
    }
}
