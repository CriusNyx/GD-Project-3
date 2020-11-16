using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;

public class Battery : MonoBehaviour
{
    public Text textObject;
    public Collider other;

    public bool playerIsTouching = false;
 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        textObject = GameObject.Find("batteryBar").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTrigger();
    }

    private void OnTrigger()
    {
        if(playerIsTouching && Input.GetKeyDown(KeyCode.E))
        {
            setText("_______________");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsTouching = false;
        }
    }

    void setText(string newText)
    {
        textObject.text = newText;
    }
}
