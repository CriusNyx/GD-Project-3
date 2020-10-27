using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToMain : MonoBehaviour
{
    AudioSource source;

    public void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
