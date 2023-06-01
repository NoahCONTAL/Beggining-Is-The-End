using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWhenCompleted : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject firstLight;
    public GameObject secondLight;
    public GameObject thirdLight;
    private bool ok = true;
    private bool ok2 = true;
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
        if (firstLight.GetComponent<isfirstlittlelevelcomplete>().completed &&
            secondLight.GetComponent<IsSecondLittleLevelComplete>().completed &&
            (thirdLight.GetComponent<IsThirdLittleLevelComplete>().completed ||
             thirdLight.GetComponent<IsThirdLittleLevelComplete>().isAlone))
        {
            levelCompleted = true;
            
            foreach (var player in players)
            {
                player.GetComponent<LevelManagger>().level1finished = true;
            }
            
        }

        if( levelCompleted && ok2)
        {
            exitDoor.transform.position += new Vector3(0, 0 , 10);
            ok2 = false;
        }
    }
}
