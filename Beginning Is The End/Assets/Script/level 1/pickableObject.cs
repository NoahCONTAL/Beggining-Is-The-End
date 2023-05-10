using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class pickableObject : MonoBehaviour
    {
        bool touched = false;

        void Update()
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                touched = false;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (!(other.CompareTag("Player") || other.CompareTag("Floor")))
            {
                touched = true;
            }
        }
    }
}