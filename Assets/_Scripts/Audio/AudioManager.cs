using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // To keep the AudioManager in every scene

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }

    private void Start()
    {
        Play(SoundType.BackgroundMusic);
    }

    public void Play(SoundType type)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == type);
        if (type == SoundType.BackgroundMusic)
        {
            s.source.Play();
        }
        else
        {
            s.source.PlayOneShot(s.clip);
        }
        
    }
}
