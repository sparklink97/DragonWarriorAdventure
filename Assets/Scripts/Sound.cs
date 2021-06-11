using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{

    public string name;
    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;
    public bool loop;
    public float volume;
    public float pitch;
    public AudioMixer mixer;

    public void Start()
    {
        mixer = Resources.Load("Mixer") as AudioMixer;
    }
}
  
