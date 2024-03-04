using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType
{
    BirdFly,
    BirdDie,
    ScorePoint
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    [Serializable]
    public class MyAudioSource
    {
        public SoundType sound;
        public AudioSource audio;
    }
    [SerializeField]
    MyAudioSource[] audioSources;

    public void playSound(SoundType sound)
    {
        foreach (MyAudioSource audioSource in audioSources)
        {
            if (audioSource.sound == sound)
                audioSource.audio.Play();
        }
    }
}
