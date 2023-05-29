using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Completed : MonoBehaviour
{    
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button1;
    Light lt;
    public bool ended;
    Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button1.GetComponent<RedLight>().completed && button1.GetComponent<RedLight>().completed && button1.GetComponent<RedLight>().completed)
        {
            
            ren = GetComponent<Renderer>();
            ren.material.color = Color.green;
            ended = true; 
            lt.color = Color.green;        
        }
    }
}
