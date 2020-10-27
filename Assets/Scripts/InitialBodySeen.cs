using System;
using UnityEngine;

public class InitialBodySeen : MonoBehaviour
{
    public Player player;
    private Boolean triggered = true;

    void OnTriggerEnter()
    {
        if (triggered)
        {
            player.PlayBodyFound();
            triggered = false;
        }
    }

}