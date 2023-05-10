using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class ShutingDoor : MonoBehaviour
    {
        [SerializeField] private GameObject button;

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && button.GetComponent<isFirstLittleLevelComplete>().completed)
            {
                transform.position += new Vector3(0, -4.02f, 0);
            }
        }
    }
}