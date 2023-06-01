using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelAccess : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    private bool ok1 = true; 
    private bool ok2 = true; 
    private bool ok3 = true; 
    private GameObject[] players;

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
            if(player.GetComponent<LevelManagger>().level1finished && ok1)
            {
                door1.transform.position += new Vector3(-20, 4, 0);
                door2.transform.position += new Vector3(20, -4, 0);
                ok1 = false;
            }
            if(player.GetComponent<LevelManagger>().level2finished && ok2)
            {
                door2.transform.position += new Vector3(-20, 4, 0);
                door3.transform.position += new Vector3(20, -4, 0);
                ok2 = false;
            }
            if(player.GetComponent<LevelManagger>().level3finished && ok3)
            {
                door3.transform.position += new Vector3(-20, 4, 0);
                ok3 = false;
            }
        }
    }

}
