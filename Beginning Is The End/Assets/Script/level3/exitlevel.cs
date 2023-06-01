using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitlevel : MonoBehaviour
{
    public GameObject exitDoor;
    private bool ok = true;
    public bool levelCompleted = false;
    public GameObject[] players;
    private bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var player in players)
        {
            if(player.GetComponent<LevelManagger>().level3finished)
            {
                complete = true;
            }
        }

        if (complete)
        {
            levelCompleted = true;
            
            foreach (var player in players)
            {
                player.GetComponent<LevelManagger>().level3finished = true;
            }
            
        }

        if( levelCompleted && ok)
        {
            exitDoor.transform.position += new Vector3(0, 0 , -10);
            ok = false;
        }
    }
}
