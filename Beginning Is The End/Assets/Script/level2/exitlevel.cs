using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitlevel : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject bigLight;
    private bool ok = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bigLight.GetComponent<Level2Completed>().ended && ok)
        {
            exitDoor.transform.position += new Vector3(10, 0, 0);
            ok = false;
        }
    }
}
