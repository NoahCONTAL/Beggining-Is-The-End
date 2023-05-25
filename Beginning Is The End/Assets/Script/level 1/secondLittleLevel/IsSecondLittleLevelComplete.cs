using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSecondLittleLevelComplete : MonoBehaviour
{
    public bool completed = false;

    Renderer ren;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (completed)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = Color.green;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            completed = true;
        }
    }


}
