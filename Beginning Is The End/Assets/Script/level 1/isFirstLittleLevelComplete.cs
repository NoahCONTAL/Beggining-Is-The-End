using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFirstLittleLevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject firstPressurePlate;
    [SerializeField] private GameObject secondPressurePlate;
    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPressurePlate.GetComponent<firstLittleLevel>().IsPressed && secondPressurePlate.GetComponent<firstLittleLevel>().IsPressed)
        {
            completed = true;
        }
        if(completed)
        {
            transform.position += new Vector3(0, 69, 0);
        }
    }
}
