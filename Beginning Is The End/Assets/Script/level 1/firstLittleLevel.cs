using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class firstLittleLevel : MonoBehaviour
    {
        public bool IsPressed = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("pickableObject"))
            {
                IsPressed = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("pickableObject"))
            {
                IsPressed = false;
            }
        }
    }
}