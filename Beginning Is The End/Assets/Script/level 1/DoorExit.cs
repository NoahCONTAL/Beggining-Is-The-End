using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool comingFromInside = false;


    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            door.transform.position += new Vector3(0, -5, 0);
            comingFromInside = true;
        }
        
        
    }

    
}
