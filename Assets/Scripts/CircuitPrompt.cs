using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircuitPrompt : MonoBehaviour
{
    public CanvasGroup preCanvas, postCanvas;
    public MonsterBehavior monster;

    void OnTriggerEnter()
    {
        if (monster.hasSpawned)
        {
            Debug.Log("Monster already spawned.");
            postCanvas.alpha = 1;
        }
        else
        {
            Debug.Log("Show fuse prompt");
            preCanvas.alpha = 1;

        }
    }

    void OnTriggerExit()
    {
        postCanvas.alpha = 0;
        preCanvas.alpha = 0;
    }
}
