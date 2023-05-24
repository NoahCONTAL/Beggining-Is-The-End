using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
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
