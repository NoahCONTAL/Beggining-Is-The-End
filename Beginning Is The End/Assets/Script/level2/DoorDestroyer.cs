using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool Actived = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            Destroy(door);
            Actived = true;
        }
    }
}
