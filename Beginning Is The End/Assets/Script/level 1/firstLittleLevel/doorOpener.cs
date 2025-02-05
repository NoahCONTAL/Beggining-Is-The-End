using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool AlreadyOnFirstPlate = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            door.transform.position += new Vector3(0, -5, 0);
            AlreadyOnFirstPlate = true;
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("pickableObject"))
        {
            door.transform.position += new Vector3(0, 5, 0);
            AlreadyOnFirstPlate = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
