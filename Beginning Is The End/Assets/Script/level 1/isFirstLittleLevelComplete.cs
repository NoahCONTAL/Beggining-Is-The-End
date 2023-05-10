using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class isFirstLittleLevelComplete : MonoBehaviour
    {
        [SerializeField] private GameObject firstPressurePlate;
        [SerializeField] private GameObject secondPressurePlate;
        public bool completed = false;

        void Update()
        {
            if (firstPressurePlate.GetComponent<firstLittleLevel>().IsPressed &&
                secondPressurePlate.GetComponent<firstLittleLevel>().IsPressed)
            {
                completed = true;
            }

            if (completed)
            {
                transform.position += new Vector3(0, 69, 0);
            }
        }
    }
}