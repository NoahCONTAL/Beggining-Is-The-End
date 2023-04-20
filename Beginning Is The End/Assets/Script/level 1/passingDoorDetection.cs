using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passingDoorDetection : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate;
    [SerializeField] GameObject door;

    void OnTriggerExit(Collider other)
    {
        bool boo = pressurePlate.GetComponent<DoorExit>().comingFromInside;
        if(other.CompareTag("Player") && boo)
        {
            door.transform.position += new Vector3(0, 5, 0);
            boo = false;
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
