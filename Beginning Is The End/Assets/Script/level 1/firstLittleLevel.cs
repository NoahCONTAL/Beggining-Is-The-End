using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstLittleLevel : MonoBehaviour
{
    public bool IsPressed = false;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("pickableObject"))
        {
            IsPressed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("pickableObject"))
        {
            IsPressed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
