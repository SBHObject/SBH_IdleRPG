using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
    private AudioSource mainAudioSource;

    protected override void Awake()
    {
        base.Awake();
        mainAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundOneShot(AudioClip clip)
    {
        mainAudioSource.PlayOneShot(clip);
    }
}
