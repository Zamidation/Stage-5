using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
    public static AudioManager instance;

    public AudioClip[] sfxClips;
    public AudioSource sfxAudioSource;
    [Range(0, 1)] public float sfxVolume = 1f;

    public AudioClip[] bgmClips;
    public AudioSource bgmAudioSource;
    [Range(0, 1)] public float bgmVolume = 0.5f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        sfxAudioSource.volume = sfxVolume;
        bgmAudioSource.volume = bgmVolume;
    }

    public void PlaySFX(int clip)
    {
        sfxAudioSource.PlayOneShot(sfxClips[clip]);
    }

    public void PlayBGM(int clip)
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = bgmClips[clip];
        bgmAudioSource.Play();
    }
}

