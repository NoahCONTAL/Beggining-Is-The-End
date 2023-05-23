using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] private GameObject firstPressurePlate;
    public bool comingFromInside = false;


    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player") && !(firstPressurePlate.GetComponent<doorOpener>().AlreadyOnFirstPlate))
        {
            door.transform.position += new Vector3(0, -5, 0);
            comingFromInside = true;
        }
        
        
    }

    
}
