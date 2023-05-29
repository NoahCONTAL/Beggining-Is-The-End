using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    [SerializeField] private GameObject firstPressurePlate;
    public bool completed = false;
    Light lt;

    Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPressurePlate.GetComponent<DoorDestroyer>().Actived)
        {
            completed = true;
            ren.material.color = Color.green;
            lt.color = Color.green;
        }
    }
}
