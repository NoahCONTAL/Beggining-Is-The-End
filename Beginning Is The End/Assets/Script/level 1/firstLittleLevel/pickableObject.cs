using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickableObject : MonoBehaviour
{
    public bool touched = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent.gameObject.GetComponent<PlayerObjects>().beingCarried = false;
            transform.parent = null;
            touched = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Player") || other.CompareTag("Floor")))
        {
            touched = true;
        }
    }
}
