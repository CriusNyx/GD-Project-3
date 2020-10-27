using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audio;
    public bool destroyWhenDone = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audio.isPlaying)
        {
            Destroy(gameObject);
        }
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
