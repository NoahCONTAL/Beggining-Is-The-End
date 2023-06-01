using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitLevel : MonoBehaviour
{
    public GameObject exitDoor;
    private bool ok = true;
    private GameObject[] players;
    private bool ended = false;


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
                ended = true;
            }
        }
        if(ended && ok)
        {
            foreach(var player in players)
            {
                player.GetComponent<LevelManagger>().level3finished = true;
            }
            exitDoor.transform.position += new Vector3(0, 0, -10);
            ok = false;
        }
    }
}
