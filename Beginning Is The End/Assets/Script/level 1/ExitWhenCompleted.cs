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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstLight.GetComponent<IsFirstLittleLevelComplete>().completed && secondLight.GetComponent<IsSecondLittleLevelComplete>().completed && thirdLight.GetComponent<IsThirdLittleLevelComplete>().completed)
        {
            levelCompleted = true;
        }
        if( levelCompleted && ok2)
        {
            exitDoor.transform.position += new Vector3(0, 0 , 10);
            ok2 = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player") && ok)
        {
            exitDoor.transform.position += new Vector3(0, 0 , -10);
            ok = false;
        }
    }
}
