using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(MainMenu.testMode == "B")
        {
            Destroy(gameObject);
        }
    }
}