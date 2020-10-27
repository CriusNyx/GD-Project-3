using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audio;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audio.isPlaying) return;
        audio.Play();
    }

    public void StopMusic()
    {
        audio.Stop();
    }

}
