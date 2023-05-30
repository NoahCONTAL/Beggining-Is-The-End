using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public GameObject Door;
    public GameObject OtherButton;
    public GameObject vitre;
    public bool pressed = false;
    private bool ok = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed && OtherButton.GetComponent<EnterLevel2>().pressed && ok)
        {
            Door.transform.position += new Vector3(0, -4, 0);
            vitre.transform.position += new Vector3(0, 2342342, 0);
            ok = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            pressed = true; 
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            pressed = false;
        }
        
    }
}
