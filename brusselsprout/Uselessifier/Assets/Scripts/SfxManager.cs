using UnityEngine;
using System.Collections;

public class SfxManager : MonoBehaviour
{
    public static SfxManager sfxManager;

    AudioSource[] _audioSources;

    void Awake()
    {
        if (!sfxManager)
            sfxManager = this;
        _audioSources = GetComponents<AudioSource>();
    }

    public void PlayClip(AudioClip clip, float volume = 1)
    {
        AudioSource audioSource = _audioSources[0];//GetAvailableAudioSource();
        if (audioSource)
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }

    AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }

        return null;
    }
}
