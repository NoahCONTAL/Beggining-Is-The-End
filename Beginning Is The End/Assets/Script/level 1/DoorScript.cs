using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject firstPressurePlate;
    [SerializeField] private GameObject secondPressurePlate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firstPressurePlate.GetComponent<firstLittleLevel>().IsPressed && secondPressurePlate.GetComponent<firstLittleLevel>().IsPressed)
        {
            DestroyGameObject();
        }
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
