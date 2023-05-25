using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThirdLittleLevelComplete : MonoBehaviour
{
    public bool completed = false;
    public bool isAlone = false;
    private GameObject[] listeofplayers;
    Renderer ren;
    private int listofplayerslength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        listeofplayers = GameObject.FindGameObjectsWithTag("Player");
        listofplayerslength = listeofplayers.Length;
        if(listofplayerslength == 1)
        {
            isAlone = true;
        }

        if (completed || isAlone)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = Color.green;
        }
    }
}
