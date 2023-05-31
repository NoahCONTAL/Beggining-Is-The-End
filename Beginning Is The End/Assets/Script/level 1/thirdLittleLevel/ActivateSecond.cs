using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSecond : MonoBehaviour
{
   public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            floor.transform.position += new Vector3(0, 0, 7);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            floor.transform.position += new Vector3(0, 0, -7);
        }
    }
}
