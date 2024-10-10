using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicsounds, sfxsounds;
    public AudioSource Musicsource, SFXsource;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);

            if (Musicsource == null) Musicsource = gameObject.AddComponent<AudioSource>();
            if (SFXsource == null) SFXsource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool IsPlaying(string name)
    {
        //Sound s = Array.Find(musicsounds, x => x.sname == name) ?? Array.Find(sfxsounds, x => x.sname == name);
        //return (Musicsource.clip == s.clip && Musicsource.isPlaying) || (SFXsource.clip == s.clip && SFXsource.isPlaying);

        Sound s = Array.Find(musicsounds, x => x.sname == name) ?? Array.Find(sfxsounds, x => x.sname == name);

        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} not found.");
            return false;
        }

        bool isMusicPlaying = Musicsource.clip == s.clip && Musicsource.isPlaying;
        bool isSFXPlaying = SFXsource.clip == s.clip && SFXsource.isPlaying;

        return isMusicPlaying || isSFXPlaying;
    }
    public void playmusic(string name)
    {
        Sound s = Array.Find(musicsounds, x => x.sname == name);
        //Debug.Log("bunyi suara musik");
        if (s != null)
        {
            Musicsource.clip = s.clip;
            //Debug.Log(s.sname);
            Musicsource.Play();
        }
    }

    public void playSFX(string name)
    {

        //Debug.Log("bunyi suara sfx");
        Sound s = Array.Find(sfxsounds, x => x.sname == name);

        if (s != null)
        {
            SFXsource.clip = s.clip;
            //Debug.Log(s.sname);
            SFXsource.PlayOneShot(s.clip);
            //Debug.Log("Playing" + s.sname);
        }
    }

    public void togglemusic()
    {
        Musicsource.mute = !Musicsource.mute;
    }
    public void toggleSFX()
    {
        Musicsource.mute = !Musicsource.mute;
    }
    public void stopmusic()
    {
        Musicsource.Stop();
    }
    public void stopsfx()
    {
        SFXsource.Stop();
    }

    public void musicvolume(float vol)
    {
        Musicsource.volume = vol;

        PlayerPrefs.SetFloat("MusicVolumes", vol);
        PlayerPrefs.Save();
    }
    public void SFXvolume(float vol)
    {
        SFXsource.volume = vol;

        PlayerPrefs.SetFloat("SFXVolumes", vol);
        PlayerPrefs.Save();
    }

}
