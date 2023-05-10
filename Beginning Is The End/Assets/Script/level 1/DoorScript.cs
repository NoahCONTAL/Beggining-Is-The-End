using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class DoorScript : MonoBehaviour
    {
        [SerializeField] private GameObject firstPressurePlate;
        [SerializeField] private GameObject secondPressurePlate;


        void Update()
        {
            if (firstPressurePlate.GetComponent<firstLittleLevel>().IsPressed &&
                secondPressurePlate.GetComponent<firstLittleLevel>().IsPressed)
            {
                DestroyGameObject();
            }
        }

        void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}