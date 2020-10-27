using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainStopTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInChildren<Player>();
        if(player != null)
        {
            player.TriggerRainStop();
            Destroy(gameObject);
        }
    }
}