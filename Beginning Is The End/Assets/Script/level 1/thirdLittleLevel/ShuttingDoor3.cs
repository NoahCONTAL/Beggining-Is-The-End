using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttingDoor3 : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Vector3 openPosition;
    private int ye = 0;

    // Start is called before the first frame update
    void Start()
    {
        openPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(button.GetComponent<IsThirdLittleLevelComplete>().isAlone && transform.position == openPosition)
        {
            transform.position += new Vector3(0, -4.02f, 0);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && button.GetComponent<IsThirdLittleLevelComplete>().completed)
        {
            ye += 1;
            if(ye == 2)
            {
                transform.position += new Vector3(0, -4.02f, 0);
            }
            
        }
    }
}
