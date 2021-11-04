using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public float MusicVolume;
    public float SfxVolume;
    public AudioMixer MusicMixer;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetMusicVolume(MusicVolume);
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        MusicMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetSfxVolume(float value)
    {
        SfxVolume = value;
        MusicMixer.SetFloat("SfxVolume", SfxVolume);
    }
}
