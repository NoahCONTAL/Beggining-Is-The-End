using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isfirstlittlelevelcomplete : MonoBehaviour
{
    [SerializeField] private GameObject firstPressurePlate;
    [SerializeField] private GameObject secondPressurePlate;
    public bool completed = false;
    Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
