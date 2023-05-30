using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public GameObject Door;
    public GameObject OtherButton;
    public GameObject OtherButton2;
    public bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed && OtherButton.GetComponent<EnterLevel2>().pressed && OtherButton2.GetComponent<EnterLevel2>().pressed )
        {
            Door.transform.position += new Vector3(0, 4, 0);
        }
    }
}
