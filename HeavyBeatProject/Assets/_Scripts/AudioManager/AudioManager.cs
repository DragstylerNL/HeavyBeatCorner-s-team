using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundCollection sounds;
    public static AudioManager instance;
    
    void Awake()
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

        foreach (Sound s in sounds.soundCollection)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.playOnAwake)
            {
                s.source.Play();
                s.source.playOnAwake = s.playOnAwake;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds.soundCollection, Sound => Sound.name == name);
        if(s==null)
        {
            print("Couldn't find " + name);
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds.soundCollection, Sound => Sound.name == name);
        if (s==null)
        {
            print("Couldn't find " + name);
            return;
        }
        s.source.Stop();
        s.source.time = 0f;
    }

    public void StopAll()
    {
        foreach (Sound s in sounds.soundCollection)
        {
            Stop(s.name);
        }
    }
}
