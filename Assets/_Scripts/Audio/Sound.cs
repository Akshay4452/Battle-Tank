using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(0.3f,3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
    private bool isSoundPlaying = false;

    public void SetSoundPlayState(bool state)
    {
        isSoundPlaying = state;
    }

    public bool GetSoundPlayState()
    {
        return isSoundPlaying;
    }
}
