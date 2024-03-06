using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // To keep the AudioManager in every scene

        foreach (Sound s in sounds)
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
        Sound s = GetSound(type);
        if(s != null && s.GetSoundPlayState() == false)
        {
            switch (type)
            {
                case SoundType.BackgroundMusic:
                    s.source.Play();
                    s.SetSoundPlayState(true);
                    break;
                case SoundType.TankIdle:
                    s.source.Play();
                    s.SetSoundPlayState(true);
                    break;
                case SoundType.TankMovement:
                    s.source.Play();
                    s.SetSoundPlayState(true);
                    break;
                case SoundType.TankTurretRotate:
                    s.source.Play();
                    s.SetSoundPlayState(true);
                    break;
                default:
                    s.source.PlayOneShot(s.clip);
                    break;
            }
        } 
    }

    public void Stop(SoundType type)
    {
        Sound s = GetSound(type);
        if (s != null && s.GetSoundPlayState() == true)
        {
            switch (type)
            {
                case SoundType.BackgroundMusic:
                    s.source.Stop();
                    s.SetSoundPlayState(false);
                    break;
                case SoundType.TankIdle:
                    s.source.Stop();
                    s.SetSoundPlayState(false);
                    break;
                case SoundType.TankMovement:
                    s.source.Stop();
                    s.SetSoundPlayState(false);
                    break;
                case SoundType.TankTurretRotate:
                    s.source.Stop();
                    s.SetSoundPlayState(false);
                    break;
                default:
                    break;
            }
        } 
    }
    public bool IsSoundPlaying(SoundType type)
    {
        Sound s = GetSound(type);
        return s.GetSoundPlayState();
    }

    private Sound GetSound(SoundType type)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == type);
        if(s != null)
            return s;
        else
            return null;
    }
}
