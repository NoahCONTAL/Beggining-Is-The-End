using System;
using UnityEngine;

namespace Objects
{
    public class MachineManager : MonoBehaviour
    {
        [SerializeField] private GameObject Machine1;
        [SerializeField] private GameObject Machine2;
        [SerializeField] private GameObject Machine3;
        [SerializeField] private GameObject Machine4;

        public bool level1finished = false;
        public bool level2finished = false;
        public bool level3finished = false;

        private void Start()
        {
            Machine1.SetActive(true);
            Machine2.SetActive(false);
            Machine3.SetActive(false);
            Machine4.SetActive(false);
        }

        private void Update()
        {
            if (level1finished)
            {
                Machine1.SetActive(false);
                Machine2.SetActive(true);
                Machine3.SetActive(false);
                Machine4.SetActive(false);
            }

            if (level2finished)
            {
                Machine1.SetActive(false);
                Machine2.SetActive(false);
                Machine3.SetActive(true);
                Machine4.SetActive(false);
            }

            if (level3finished)
            {
                Machine1.SetActive(false);
                Machine2.SetActive(false);
                Machine3.SetActive(false);
                Machine4.SetActive(true);
            }
        }
    }
}