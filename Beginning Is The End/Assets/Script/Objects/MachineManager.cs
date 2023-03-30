using System;
using UnityEngine;

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
        }
        else if (level2finished)
        {
            Machine2.SetActive(false);
            Machine3.SetActive(true);
        }
        else if (level3finished)
        {
            Machine3.SetActive(false);
            Machine4.SetActive(true);
        }
    }
}
