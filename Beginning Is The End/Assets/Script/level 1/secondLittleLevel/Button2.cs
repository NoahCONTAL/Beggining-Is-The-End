using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{

    public Transform tar1;
    public Transform tar2;
    public Transform tar3;


    Vector3 b1;

    Vector3 b2;

    Vector3 b3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        b1 = tar1.position;

        b2 = tar2.position;

        b3 = tar3.position;
    
    }

    public void execute()
    {
        if(b2.y > -1.36 )
        {
            tar2.position += new Vector3(0, -1.18f, 0);
        }

        if(b3.y < 1.36 )
        {
            tar3.position += new Vector3(0, 1.18f, 0);
        }
        
    }
}
