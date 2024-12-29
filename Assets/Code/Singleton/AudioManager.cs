using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // gunakan singleton pattern sesuai ini!
    private static AudioManager _instance;
    private AudioSource audioSource;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("AudioManager still null!");
            }
            return _instance;
        }
    }


    void Awake()
    {
       _instance = this;
       audioSource = GetComponent<AudioSource>();

    }

    public void playSFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip,1f);
    }
}
