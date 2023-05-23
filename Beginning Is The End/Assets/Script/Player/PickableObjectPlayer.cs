using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectPlayer : MonoBehaviour
{
    private GameObject[] pickableObjects;
    public Transform player;
    public float throwForce = 10;
    

    public bool hasPlayer = false;
    public bool beingCarried = false;
    public bool touched = false;

    void Start()
    {
        pickableObjects = GameObject.FindGameObjectsWithTag("pickableObject");
    }
    void Update()
    {
        foreach (GameObject pickableObject in pickableObjects)
       { 
            float disk =
                Vector3.Distance(pickableObject.transform.position, transform.position);

            hasPlayer = (disk <= 1.9f);

            if (beingCarried)
            {
                if (Input.GetButton("Use"))
                {
                    pickableObject.GetComponent<Rigidbody>().isKinematic = false;
                    pickableObject.transform.parent = null;
                    beingCarried = false;
                    return;
                }
            }

            if (hasPlayer && Input.GetButton("Use"))
            {
                pickableObject.GetComponent<Rigidbody>().isKinematic = true;
                pickableObject.transform.parent = player;
                beingCarried = true;
            }
       }
    }
}