using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Vector3 teleportPosition;
    [SerializeField] private Vector3 teleportRotation; 
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            other.transform.position = teleportPosition;
            other.transform.rotation = Quaternion.Euler(teleportRotation);
        }
    }
}
