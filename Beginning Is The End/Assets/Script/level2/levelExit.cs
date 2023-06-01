using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelExit : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject bigLight;
    private bool ok = true;
    public bool levelCompleted = false;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        if (bigLight.GetComponent<Level2Completed>().ended)
        {
            levelCompleted = true;
            
            foreach (var player in players)
            {
                player.GetComponent<LevelManagger>().level2finished = true;
            }
            
        }

        if( levelCompleted && ok)
        {
            exitDoor.transform.position += new Vector3(10, 0 , 0);
            ok = false;
        }
    }
}
