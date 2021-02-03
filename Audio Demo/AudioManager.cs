using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // current instance of audio manager, to stop duplicates adding in new scenes
    // need to add audiomanager prefab to each scene
    public static AudioManager instance;

    private enum AudioGroups { Music, SFX };

    [HideInInspector]
    public bool drawing_playing = false;
    [HideInInspector]
    public bool flame1 = false;
    [HideInInspector]
    public bool flame2 = false;
    [HideInInspector]
    public bool flame3 = false;

    private bool outsideMusic = false;
    private bool insideMusic = false;
    private bool fire_crackle = false;
    private bool firefly = false;

    private bool draw = false;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Audio Manager opened");

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.spread = s.spread;
            s.source.spatialBlend = s.spatialBlend;
            s.source.outputAudioMixerGroup = s.mixerGroup; // mixerGroup
        }
        Debug.Log("HERE MUSIC");
        Music();
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            if(s.play_on_start == true)
            {
                Play(s.name);
            }
        }
    }

    public void Music()
    {
        Debug.Log("Music function");
        string current = SceneManager.GetActiveScene().name;

        if (current == "outside")
        {
            if (insideMusic)
            {
                Stop("inside_music");
                insideMusic = false;
            }
            if (!outsideMusic)
            {
                Play("outside_music");
                outsideMusic = true;
            }
        }
        else
        {
            Debug.Log("In else");
            if (outsideMusic)
            {
                Stop("outside_music");
                outsideMusic = false;
            }
            if (!insideMusic)
            {
                Debug.Log("In IF");
                Play("inside_music");
                insideMusic = true;
            }
        }
    }

    public void Play(string name)
    {
        Debug.Log("PLAY  " + name);
        // to play sound from another script
        // FindObjectOfType<AudioManager>().Play("name");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.Play();

    }

    public void ChangeVolume(string name, int value)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.volume += value;
    }

    public void ChangePitch(string name, int value)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.pitch += value;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.UnPause();
    }
}

