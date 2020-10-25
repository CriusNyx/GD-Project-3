using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textObject;
    public Light lt;
    public int lightDrainSpeed = 20;
    void Start()
    {
        InvokeRepeating("drain", 3, lightDrainSpeed);
     
    }

    // Update is called once per frame
    void Update()
    {
        //if(player finds a battery){
        //  add "_" to textObject.text 
        //}
        

    
      
    }

    void drain()
    {
        
        if (textObject.text.Length > 0)
        {
            textObject.text = textObject.text.Remove(textObject.text.Length - 1, 1);
        }
        else
        {
             lt.intensity = 0;
            //trigger end game screen here
            
        }
    
    }
}
  