using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttingDoor2 : MonoBehaviour
{
    [SerializeField] private GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && button.GetComponent<IsSecondLittleLevelComplete>().completed)
        {
            transform.position += new Vector3(0, -4.02f, 0);
        }
    }
}
