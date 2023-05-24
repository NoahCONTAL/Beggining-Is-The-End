using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
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
        if (other.CompareTag("Player") && button.GetComponent<RedLight>().completed)
        {
            transform.position += new Vector3(0, -4.02f, 0);
        }
    }
}
