using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel2 : MonoBehaviour
{
    public bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            pressed = true;
        }
        
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            pressed = false;
        }
    }
}
