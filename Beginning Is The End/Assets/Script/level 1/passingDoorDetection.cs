using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passingDoorDetection : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate;
    [SerializeField] private GameObject pressurePlateInside;
    [SerializeField] GameObject door;

    void OnTriggerExit(Collider other)
    {
        bool boo = pressurePlateInside.GetComponent<DoorExit>().comingFromInside;
        if(other.CompareTag("Player") && boo && !(pressurePlate.GetComponent<doorOpener>().AlreadyOnFirstPlate))
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
