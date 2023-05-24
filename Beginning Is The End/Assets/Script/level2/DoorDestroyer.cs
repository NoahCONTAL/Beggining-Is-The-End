using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool AlreadyOnFirstPlate = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            Destroy(door);
            AlreadyOnFirstPlate = true;
        }
    }
}
