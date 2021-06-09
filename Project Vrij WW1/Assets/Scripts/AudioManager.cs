using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public string currentAmbience;
    public string prevAmbience;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        currentAmbience = "NormalAmbience";
    }

    void Update()
    {
        if(prevAmbience != currentAmbience || prevAmbience == null)
        {
            
            PlaySound(currentAmbience);

            if(prevAmbience != null)
            {
                StopSound(prevAmbience);
            }
            prevAmbience = currentAmbience;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log(name + " bestaat niet :c");
        }
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log(name + " bestaat niet :c");
            return;
        }
        if (s.source.isPlaying)
        {
            s.source.Stop();
        }

    }

}
