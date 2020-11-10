using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhonePrompt : MonoBehaviour
{
    public CanvasGroup promptCanvas;
    public MonsterBehavior monster;
    public AudioSource copsCalled;

    void OnTriggerEnter()
    {
        if (monster.hasSpawned)
        {
            StartCoroutine(Victory());
        }
        else
        {
            promptCanvas.alpha = 1;
            Debug.Log("Show phone prompt");
        }
    }


    void OnTriggerExit()
    {
        promptCanvas.alpha = 0;
    }

    IEnumerator Victory()
    {
        Debug.Log("You win!");
        copsCalled.Play();
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
