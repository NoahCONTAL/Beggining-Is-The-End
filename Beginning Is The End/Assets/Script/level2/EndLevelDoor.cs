using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject Montante;

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
            transform.position += new Vector3(0, -6.02f, 0);
            Montante.transform.position += new Vector3(0, 6.02f, 0);
        }
    }
}
