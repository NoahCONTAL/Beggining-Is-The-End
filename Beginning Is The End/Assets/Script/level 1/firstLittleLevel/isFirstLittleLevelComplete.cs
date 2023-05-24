using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFirstLittleLevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject firstPressurePlate;
    [SerializeField] private GameObject secondPressurePlate;
    public bool completed = false;
    Renderer ren;
    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstPressurePlate.GetComponent<firstLittleLevel>().IsPressed && secondPressurePlate.GetComponent<firstLittleLevel>().IsPressed)
        {
            completed = true;
        }
        if (completed)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = Color.green;
            lt.color = Color.green;
        }
    }
}
