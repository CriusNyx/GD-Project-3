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

 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        textObject = GameObject.Find("batteryBar").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTrigger(other);

    }

    void OnTrigger(Collider other)
    {

        string y = "_______________";
        if (other.tag == "Player")

        {
            
            KeyCode key = KeyCode.E;
           

            if (Input.GetKeyDown(key))
            {

               // Destroy(other.gameObject); 
                setText(y);
               

            }
    


        }
 
        
    }

    void setText(string newText)
    {
        textObject.text = newText;
    }
}
